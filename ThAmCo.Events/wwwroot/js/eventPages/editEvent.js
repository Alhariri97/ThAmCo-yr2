
import { fireAllert, alertInfo } from '../swal.js';


// apply select2 (client side library) to the multiy selectes 
$("#SelectedStaffs").select2();
$("#SelectedGuests").select2();



$('.cancel-venu').on("click", function () {
    var eventId = $(this).data('event-id');
    var reservationId = $(this).data('reservation-id');

    cancelVenuAllertAndCall(eventId, reservationId)
});
function cancelVenuAllertAndCall(eventId, reservationId) {
    fireAllert("Are you sure you want to Cancel this venu booking?",
        "You won't be able to revert this!",
        "warning",
        "Confirm Cancellation",
        "No Cancel and Back",
    ).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/Event/CancelVenue`,
                method: "PUT",
                data: { eventId: eventId, reservationId: reservationId },
                success: () =>
                    alertInfo("Canceled!", "Venue has been canceled.", "success")
                        .then(() => location.reload()),
                error: () => alertInfo("Opps!", "Something went wrong.", "error"),
            });
        }
    });
}

//Code For selecting an avalible Venu

var tomorrowDate = $("#TomorrowDate").val();
var endDate = $("#EventDate").val();
var selectedEventType = $("#EventTypeId").val();
// invoe the func to get avalibleVenus
getAvalibleVenus();

// Event handler for when the availability is selected
var SelectedAvailabilityDropDownList = $("#SelectedAvailability");

SelectedAvailabilityDropDownList.on('change', function () {
    if ($(this).val()) {
        var selectedAvailability = JSON.parse($(this).val());
        // Display the rest of the details when the option is selected
        displayAvailabilityDetails(selectedAvailability);
        // Get the date of the selected availability
    } else {
        var selectedAvailabilityDetailsDiv = $("#selectedAvailabilityDetails");
        selectedAvailabilityDetailsDiv.empty();
    }
});

// Function to display availability details
function displayAvailabilityDetails(selectedAvailabilityChosen) {
    // Update the selected availability details div with the received data
    var selectedAvailabilityDetailsDiv = $("#selectedAvailabilityDetails");
    selectedAvailabilityDetailsDiv.empty();

    // Construct HTML for the selected availability details
    var selectedAvailabilityHtml = `
                                <div class="card border-light mt-4" >
                                    <div class="card-header">${selectedAvailabilityChosen.name || 'N/A'}</div>
                                    <div class="card-body">
                                        <h6 class="card-title"> ${new Date(selectedAvailabilityChosen.date).toLocaleDateString() || 'N/A'} </h6>
                                        <p class="card-text"> ${selectedAvailabilityChosen.description || 'N/A'}</p>
                                        </div>
                                </div>
                            `;

    selectedAvailabilityDetailsDiv.append(selectedAvailabilityHtml);
}

function getAvalibleVenus() {
    $.ajax({
        url: `https://localhost:7088/api/Availability?eventType=${selectedEventType}&beginDate=${tomorrowDate}&endDate=${endDate}`,
        type: "GET",
        success: function (data) {
            // Update the availability dropdown with the received data
            SelectedAvailabilityDropDownList.empty();

            if (data.length > 0) {
                SelectedAvailabilityDropDownList.prop("disabled", false);

                // If availabilities are present, populate the dropdown
                SelectedAvailabilityDropDownList.append('<option value="">Select Availability</option>');

                // Iterate through the data and append options with name and date
                $.each(data, function (index, item) {
                    // Construct HTML for each option with name and date
                    var optionText = `${item.name} - ${new Date(item.date).toLocaleDateString()}`;
                    var option = new Option(optionText, JSON.stringify(item));
                    SelectedAvailabilityDropDownList.append(option);
                });
            } else {
                $("#availabilityId").prop("disabled", true);
                // If no availabilities, display a message in the dropdown
                SelectedAvailabilityDropDownList.append('<option value="">No available venues for these dates</option>');
            }
        },
        error: (error) => console.log("Error fetching availabilities:", error)

    });
}


$('.cancel-food').on("click", function () {

    let eventId = $(this).data('event-id');
    var foodBookingId = $(this).data('foodbooking-id');

    cancelFoodBookingAllertAndCall(eventId, foodBookingId)
});

function cancelFoodBookingAllertAndCall(eventId, foodBookingId) {
    fireAllert("Are you sure you want to Cancel this Food booking?",
        "You won't be able to revert this!",
        "warning", "Confirm Cancellation",
        "No Cancel and Back").then((result) => {
            console.log(result)

            if (result.isConfirmed) {
                $.ajax({
                    url: `/Event/CancelFoodBooking`,
                    method: "PUT",
                    data: { eventId: eventId, foodBookingId: foodBookingId },
                    success: () =>
                        alertInfo("Canceled!", "Venue has been canceled.", "success")
                            .then(() => location.reload()),
                    error: () => alertInfo("Opps!", "Something went wrong.", "error"),
                });
            }
        });
}

