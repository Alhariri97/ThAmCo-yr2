import { fireAllert, alertInfo } from '../swal.js';

let classForHidding = 'd-none'

$('.cancel-event').on('click', function() {
    var btn = $(this);
    var eventId = btn.data("event-id");
    console.log(eventId);
    fireAllert("Are you sure you want to Cancel this event?",
        "You won't be able to revert this!",
        "warning", "Confirm Cancellation"
        , "No Cancel and Back")
        .then((result) => {
            if (result.isConfirmed) {
                // It's a empty so it's a delete
                $.ajax({
                    url: `Event/Cancel/${eventId}`,
                    method: "PUT",
                    data: { eventId: eventId },
                    success: () =>
                        alertInfo("Canceled!", "Your Event has been canceled", "success")
                            .then((ok) => {
                                location.reload();
                            }),
                    error: () =>
                        alertInfo("Opps!", "Something went worng, could not cancel this event! ", "error")
                });
            }
        });

});
$('.delete-event').on('click', function () {
    var btn = $(this);
    var eventId = btn.data("event-id");
    console.log(eventId);
    fireAllert("Are you sure you want to delete this event?",
        "You won't be able to revert this!",
        "warning", "Confirm Deletion"
        , "No Cancel and Back")
        .then((result) => {
            if (result.isConfirmed) {
                // It's a empty so it's a delete
                $.ajax({
                    url: `Event/Delete/${eventId}`,
                    method: "PUT",
                    data: { eventId: eventId },
                    success: () =>
                        alertInfo("Delete!", "Your Event has been Deleted", "success")
                            .then((ok) => {
                                location.reload();
                            }),
                    error: () =>
                        alertInfo("Opps!", "Something went worng, could not Delete this event! ", "error")
                });
            }
        });
});



