# # ThAmCo Full Stack C# Project

## Overview

This is a full-stack C# project that includes web services and a web application for managing catering, events, guests, staff, and venues.

## Project Structure

### ThAmCo.Catering
Web services for catering-related operations, including the creation, editing, and deletion of food items, menus, and food bookings.

### ThAmCo.Events
Web services for event-related operations, such as creating, editing, and canceling events. It also includes functionality for booking guests onto events and managing staff assignments.

### ThAmCo.Venues
Web services for managing venues, including reserving venues for events.

### ThAmCo.Guests
Module for creating, listing, and editing guest information. It also includes features for displaying guest details and managing guest bookings for events.

### ThAmCo.Staff
Module for creating, listing, and editing staff information. It also includes functionality for adjusting staff assignments for events and displaying staff details.

## Functional Requirements

### Web Services - ThAmCo.Catering

- Create, edit, delete, and list food items.
- Create, edit, delete, and list menus.
- Add and remove a food item from a menu.
- Book, edit, and cancel food for an event.

### ThAmCo.Guests Module

- Create, list, and edit guests.
- Book a guest onto an event.
- List guests for an event and register their attendance.
- Display details of a guest, including information about associated events and attendance.

### ThAmCo.Events Module

- Create a new event, specifying at least its title, date, and event type.
- Edit an event (excluding its date and type).
- Cancel (soft delete) an event, freeing any associated venue and staff.
- Adjust the staffing of an event, adding available staff or removing currently assigned staff.

### ThAmCo.Venues Module

- Reserve an appropriate, available venue for an event via the ThAmCo.Venues web service, freeing any previously associated venue.

### ThAmCo.Staff Module

- Create, list, and edit staff information.
- Display details of a staff member, including information about upcoming events they are assigned to work.

### Web Application User Features

- Cancel the booking of a guest from an upcoming event.
- Display a list of events with summary information about guests and venues.
- Display warnings within event list and staffing views when there is no first aider assigned to an event.
- Display detailed information for an event, including details of the venue, staff, and guests.
- Permanently remove personal data by anonymizing the guest entity.
- Display a detailed list of available venues, filtered by event type and date range. Create a new event by picking a result from the venue list.
- Display warnings within event list and staffing views when there are fewer than one member of staff per 10 guests assigned to an event.

## Development Setup

1. 
2. Open the solution file in Visual Studio.
3. Restore NuGet packages and build the solution.
4. foreach broject: 
    1- catering, 
    2- venues,
    3- staff
run `update-database`
5. Start the web application.

## User Access Control

User access control is implemented to restrict access based on user registered.
role access is ready to implement but did not have time to implement it.
## Contributing

Feel free to contribute to this project by submitting issues or pull requests. Follow the project's coding standards and guidelines.

## License

This project is free for use, Develop, deploy.
