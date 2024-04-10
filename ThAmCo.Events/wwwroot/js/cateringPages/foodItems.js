import { fireAllert, alertInfo, noteInfoTopRight } from '../swal.js';

$("#create-food-item").on("click", function () {
    Swal.fire({
        title: `<h5 class="color-white" >  Create Food Item  </h5>`,

        cancelButtonColor: "#3085d6",

        html:
            '<input id="swal-input-name" class="swal2-input color-white" placeholder="Name">' +
            '<input id="swal-input-price" class="swal2-input color-white" placeholder="Price">' +
            '<input id="swal-input-desc" class="swal2-input color-white" placeholder="Description">',
        showCancelButton: true,
        confirmButtonText: 'Create',
        focusConfirm: false,
        preConfirm: () => {
            const name = Swal.getPopup().querySelector('#swal-input-name').value;
            const price = Swal.getPopup().querySelector('#swal-input-price').value;
            const desc = Swal.getPopup().querySelector('#swal-input-desc').value;

            if (!name || !price || !desc) {
                Swal.showValidationMessage('Please fill in all fields');
            }

            // Validate if the entered price is a valid number
            if (isNaN(price)) {
                Swal.showValidationMessage('Price must be a valid number');
                return false;
            }

            return { name: name, price: price, desc: desc };
        }
    }).then((result) => {
        if (result.isConfirmed) {
            const { name, price, desc } = result.value;

            $.ajax({
                url: '/Catering/CreateFoodItem',
                type: 'POST',
                data: { name: name, price: price, desc: desc },
                success: () =>
                    alertInfo("Creaetd!", "Your new foodItem has been created.", "success")
                        .then(() => location.reload())
                ,
                error: () => alertInfo("Opps!", "Something went wrong.", "error")
            });
        }
    });
});

///
// code for Deleting a food item
///
$(".delete-food-item").on("click", function () {
    var btn = $(this);
    var foodItemId = btn.data("fooditem-id");

    fireAllert("Are you sure you want to delete this food item?",
        "You won't be able to revert this!",
        "warning", "Yes, delete it!",
        "No  Back")
        .then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Catering/DeleteFoodItem/${foodItemId}`,
                    type: 'Delete',
                    success: () =>
                        alertInfo("Deleted!", "Your food item has been deleted.", "success")
                            .then(() => location.reload())
                    ,
                    error: () => alertInfo("Opps!", "Something went wrong.", "error")
                });
            }
        });
});

///
// Code for Details of a food item
///
$(".details-food-item").on("click", function () {
    var btn = $(this);
    var foodItemId = btn.data("fooditem-id");
    $.ajax({
        url: `/Catering/FoodItemDetails/${foodItemId}`,
        type: 'GET',
        success: (data) =>
            Swal.fire({
                html: `
                        <div class="card-body ">
                            <h4 class="card-title color-white">${data.name}</h4>
                            <h5 class="color-white" > Price: £${data.unitPrice}</h5>
                            <p class="card-text color-white"> ${data.description}</p>
                        </div>
                      `,
            })
        ,
        error: () => alertInfo("Opps!", "Something went wrong.", "error")
    });
});

///
// Code for Editing a food item
///
$(".edit-food-item").on("click", function () {
    var btn = $(this);
    var foodItemId = btn.data("fooditem-id");

    // Find the parent row of the clicked button and extract data from its cells
    var row = btn.closest('tr');
    var name = row.find('td:eq(0)').text(); //  the first cell contains the name
    var price = row.find('td:eq(1)').text(); //  the second cell contains the price
    var desc = row.find('td:eq(2)').text(); //  the third cell contains the description

    // Use the retrieved data to pre-fill the Swal input fields
    Swal.fire({
        title: `<h5 class="color-white" >  Edit Food Item  </h5>`,

        cancelButtonColor: "#3085d6",
        html:
            `
                <input id="swal-input-name"  class="swal2-input color-white" placeholder="Name" value="${name}">
                <input  id="swal-input-price" class="swal2-input color-white" placeholder="Price" value="${price}">
                <input id="swal-input-desc" class="swal2-input color-white" placeholder="Description" value="${desc}">
            `,
        showCancelButton: true,
        focusConfirm: false,
        preConfirm: () => {
            const name = Swal.getPopup().querySelector('#swal-input-name').value;
            const price = Swal.getPopup().querySelector('#swal-input-price').value;
            const desc = Swal.getPopup().querySelector('#swal-input-desc').value;

            if (!name || !price || !desc) {
                Swal.showValidationMessage('Please fill in all fields');
                return false;
            }

            // Validate if the entered price is a valid number
            if (isNaN(price)) {
                Swal.showValidationMessage('Price must be a valid number');
                return false;
            }

            return { name: name, price: price, desc: desc };
        }
    }).then((result) => {
        if (result.isConfirmed) {
            const { name, price, desc } = result.value;


            $.ajax({
                url: `/Catering/EditFoodItem/${foodItemId}`,
                type: 'PUT',
                data: { name: name, price: price, desc: desc },
                success: () =>
                    noteInfoTopRight("Updated", )
                        .then(() => location.reload())
                ,
                error: () => noteInfoTopRight( "Opps!", "info")
            });
        }
    });
});

