import { fireAllert, alertInfo } from '../swal.js';

$(".js-delete-cancel").on("click", function () {
    var btn = $(this);
    var foodBookingId = btn.data("foodbooking-id");

    var deleteOrCancel = btn.data("client-reference-id") == ""; //true = delete, false == cancel


    fireAllert("Are you sure you want to " + (deleteOrCancel ? "Delete" : "Cancel") + " this food booking?",
        "You won't be able to revert this!",
        "warning", (deleteOrCancel ? "Confirm Deletion Booking" : "Confirm Cancellation !")
        , "No Cancel and Back")
        .then((result) => {
            if (result.isConfirmed) {
                if (deleteOrCancel) {
                    // It's a empty so it's a delete
                    $.ajax({
                        url: `Catering/DeleteFoodBooking/${foodBookingId}`,
                        method: "DELETE",
                        success: () =>
                            alertInfo("Deleted!", "Your food booking has been deleted", "success")
                                .then((ok) => {
                                    location.reload();
                                }),
                        error: () =>
                            alertInfo("Opps!", "Something went worng, could not delete this food booking ", "error")
                    });
                } else {
                    // It's not a number so it's a cancel
                    $.ajax({
                        url: `Catering/CancelFoodBooking/${foodBookingId}`,
                        method: "PUT",
                        success: () =>
                            alertInfo("Canceled!", "Your food booking has been canceled", "success")
                                .then((ok) => {
                                    location.reload();
                                }),
                        error: () =>
                            alertInfo("Opps!", "Something went worng, could not cancel this food booking ", "error")
                    });
                }
            }
        });
});