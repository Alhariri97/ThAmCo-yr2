
// get the value of the selected option!
$("#EventTypeName").val($("#EventTypeId option:selected").text());
// For Assign staff and Guests Select:
$("#SelectedStaffs").select2();
$("#SelectedGuests").select2();

//For selecting an avalible Venu


var SelectedAvailabilityDropDownList = $("#SelectedAvailability");
SelectedAvailabilityDropDownList.prop("disabled", true);
var selectedAvailabilityHtml = $("#selectedAvailabilityDetails");



function makeAvailabilityRequest() {
    var selectedEventType = $("#EventTypeId").val();
    var selectedDate = $("#EventDate").val();
    var selectedAvailabilityDetailsDiv = $("#selectedAvailabilityDetails");

    var tomorrowDate = $("#TomorrowDate").val();

    var selectedText = $("#EventTypeId option:selected").text();
    $("#EventTypeName").val(selectedText);


    selectedAvailabilityHtml.empty();
    selectedAvailabilityDetailsDiv.empty();
    // Check if both event type and dates are selected before making the AJAX call
    if (selectedEventType && selectedDate) {
        // Make an AJAX call to the API to get availabilities based on the selected event type and dates
        selectedAvailabilityHtml.empty();
        SelectedAvailabilityDropDownList.prop("disabled", true);

        $.ajax({
            url: `https://localhost:7088/api/Availability?eventType=${selectedEventType}&beginDate=${tomorrowDate}&endDate=${selectedDate}`,
            type: "GET",
            success: (data) => {
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
            error: (error) =>
                console.log("Error fetching availabilities:", error)
        });
    } else {
        SelectedAvailabilityDropDownList.empty();
        SelectedAvailabilityDropDownList.append('<option value="">Please select event type and start/end dates.</option>');

        SelectedAvailabilityDropDownList.prop("disabled", true);
    }
}

// Event handler for when the event type is selected
$("#EventTypeId").on('change', () => makeAvailabilityRequest());

// Event handler for when the event type is selected
$("#EventDate").on('change', () => makeAvailabilityRequest());

// Event handler for when the availability is selected
SelectedAvailabilityDropDownList.on('change', function () {
    if ($(this).val()) {
        var selectedAvailability = JSON.parse($(this).val());

        // Display the rest of the details when the option is selected
        displayAvailabilityDetails(selectedAvailability);

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