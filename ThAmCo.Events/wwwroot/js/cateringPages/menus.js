import { fireAllert, alertInfo, noteInfoTopRight } from '../swal.js';



let oldFoodItems = [];
let newFoodItems = [];


///
// code to get the food items for a menu
///
$(".accordion-button").on("click", function () {
    var menuId = $(this).data("menu-id");
    $.ajax({
        url: `/Catering/GetMenuWithFoodItems/${menuId}`,
        type: 'GET',
        success: (data) => {
            oldFoodItems = data.foodItems.map(foodItem => foodItem.foodItemId);
            renderFoodItems(data.foodItems, menuId);
        },
        error: (error) => console.error("Error fetching food items:", error)
    });
});


///
// code for add a food item to the menu
///
$(".add-food-btn").on("click", function () {
    var menuId = $(this).data("menu-id");

    $.ajax({
        url: `/Catering/GetAllFoodItemsForMenu/${menuId}`,
        type: 'GET',
        success: function (data) {
            var optionsHtml = "";
            if (data.length > 0) {
                data.forEach(function (foodItem) {
                    optionsHtml += `<option value="${foodItem.foodItemId}">${foodItem.name} - ${foodItem.unitPrice}</option>`;
                });
            } else {
                optionsHtml = "<option value='' disabled>No food items available</option>";
            }

            Swal.fire({
                title: "Select Food Items",
                html:
                    `
                          <div class="form-group">
                              <label class="form-label mt-4">Select food items</label>
                              <select multiple class="form-select js-select" >
                                ${optionsHtml}
                              </select>
                        </div>
                        `,
                showCancelButton: true,
                confirmButtonText: 'Add to Menu',
                preConfirm: () => $('.js-select').val()
            }).then(function (result) {
                if (result.isConfirmed) {
                    var selectedFoodItemIds = result.value;
                    if (selectedFoodItemIds < 1) {

                        noteInfoTopRight("No food Items to add!", "question",)
                    } else {
                        let OldWithNewFoodItemsId = [...selectedFoodItemIds, ...oldFoodItems];

                        $.ajax({
                            url: `/Catering/EditMenuFoodItems/${menuId}`,
                            type: 'PUT',
                            data: { numbers: OldWithNewFoodItemsId },
                            success: () => {
                                noteInfoTopRight("Food items has been added", "success")
                                    .then(() => location.reload())
                            },
                            error: () => noteInfoTopRight("Ops could not add food items!", "error",)
                        });
                    }
                }


            });
            $('.js-select').select2();
        },
        error: () => console.error("Error fetching food items:", error)
    });
});

///
// function for the displaying fooditems
////
function renderFoodItems(foodItems, menuId) {
    var accordionBody = $("#" + `accordionBody-${menuId}`);
    accordionBody.empty(); // Clear previous content

    if (foodItems.length > 0) {
        var list = $("<ul class='list-group'></ul>");
        foodItems.forEach(function (foodItem) {
            var listItem = $("<li class='list-group-item d-flex justify-content-between'></li>");

            // Add a delete icon with a specific class and data attribute
            var deleteIcon = $(`
                        <a class="btn btn-danger rounded rounded-3 me-2 delete-icon"
                           data-toggle="tooltip"
                           data-placement="top"
                           data-menu-id="${menuId}"
                           data-food-item-id="${foodItem.foodItemId}"
                           title="Delete">
                            <i class="bi bi-trash3"></i>
                        </a>`);
            listItem.html(`${foodItem.name} -  ${foodItem.unitPrice} `);
            listItem.append(deleteIcon);
            list.append(listItem);
        });
        accordionBody.html(list);
        // Use event delegation for dynamically added elements
        accordionBody.off('click', '.delete-icon').on('click', '.delete-icon', function () {
            var foodItemId = $(this).data('food-item-id');
            var clickedMenuId = $(this).data('menu-id');
            handelDeleteFoodItem(foodItemId, clickedMenuId, foodItems)
        });
    } else {
        accordionBody.text("No food items available for this menu.");
    }
}

///
// function for the delete icon click
///
function handelDeleteFoodItem(foodItemId, menuId, allFoodItems) {
    //extract the ids for food items and then delete the selected food item
    let wantedItems = allFoodItems
        .map(foodItem => foodItem.foodItemId)
        .filter(item => item !== foodItemId);

    $.ajax({
        url: `/Catering/EditMenuFoodItems/${menuId}`,
        type: 'PUT',
        data: { numbers: wantedItems },
        success: () => {
            noteInfoTopRight("Food items has been Deleted", "success")
                .then(() => location.reload())
        },
        error: () => noteInfoTopRight("Oops could not delete food items!", "error")
    });

}

///
// code for Creating a food Menu
///
$("#create-food-menu").on("click", function () {
    Swal.fire({
        title: `<h5 class="color-white">  Create Food Menu </h5>`,
        cancelButtonColor: "#3085d6",
        html:
            '<input id="swal-input-name" class="swal2-input color-white" placeholder="Name">',

        showCancelButton: true,
        confirmButtonText: 'Create',
        focusConfirm: false,
        preConfirm: () => {
            const name = Swal.getPopup().querySelector('#swal-input-name').value;
            if (!name) {
                Swal.showValidationMessage('Please write a name');
            }
            return { name: name };
        }
    }).then((result) => {
        if (result.isConfirmed) {
            const { name } = result.value;

            $.ajax({
                url: '/Catering/CreateMenu',
                type: 'POST',
                data: { name: name },
                success: () => {
                    alertInfo("Creaetd!", "Menu has been created.", "success")
                        .then(() => location.reload())

                },

                error: () => alertInfo("Opps!", "Something went wrong Could not create menu.", "error")
            });
        }
    });
});


///
// code for changeing a name of a food Menu
///
$(".change-name-btn").on("click", function () {
    var menuId = $(this).data("menu-id");

    Swal.fire({
        title: `<h5 class="color-white">  Change Food Menu name </h5>`,
        cancelButtonColor: "#3085d6",
        html:
            '<input id="swal-input-name" value="" class="swal2-input color-white " placeholder="New mame">',

        showCancelButton: true,
        confirmButtonText: 'Change',
        focusConfirm: false,
        preConfirm: () => {
            const name = Swal.getPopup().querySelector('#swal-input-name').value;

            if (!name) {
                Swal.showValidationMessage('Please write a name');
            }
            return { name: name };
        }
    }).then((result) => {

        if (result.isConfirmed) {

            $.ajax({
                url: '/Catering/UpdateMenu',
                type: 'PUT',
                data: { menuId: menuId, newName: result.value.name },
                success: () => {
                    alertInfo("Updated!", "Menu name has been updated.", "success")
                        .then(() => location.reload())
                },
                error: () => alertInfo("Opps!", "Something went wrong, could not change menu menu Name.", "error")
            });
        }
    });

});




///
// code for deleteing a food Menu
///
$(".delete-menu-btn").on("click", function () {
    var menuId = $(this).data("menu-id");

    fireAllert("Are you sure you want to delete this menu ?",
        "Food items related won't be deleted!", "warning",
        "Yes, delete it!", "No, cancel!")
        .then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Catering/DeleteMenu',
                    type: 'DELETE',
                    data: { menuId: menuId },
                    success: () => {
                        alertInfo("Deleted!", "Menu has been deleted.", "success")
                            .then(() => location.reload())
                    },
                    error: () => alertInfo("Can't be deleted!", "This menu is used in a food booking .", "error")
                });
            }
        })
});

