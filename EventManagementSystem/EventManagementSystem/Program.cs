using EventManagementSystem.Reports;
using EventManagementSystem.Services;

EventService service = new EventService();
EventReport report = new EventReport();

Console.WriteLine("========== Event Management System ==========");
Console.WriteLine("1- Events By Organizer");
Console.WriteLine("2- Attendees By Event");
Console.WriteLine("3- Total Revenue Per Event");
Console.WriteLine("4- Number Of Attendees Per Event");
Console.WriteLine("5- Upcoming Events");
Console.WriteLine("6- Attendees Not Checked In");
Console.WriteLine("7- Most Attended Events");
Console.WriteLine("8- Event Details");
Console.WriteLine("9- Attendees Attending Multiple Events");
Console.WriteLine("10- Fully Booked Events");
Console.WriteLine("11- Generate Event Report");
Console.WriteLine("12- Attendee Check In Report");
Console.WriteLine("============================================");

Console.Write("\nChoose: ");

if (int.TryParse(Console.ReadLine(), out int choice))
{
    Console.WriteLine("\n-----------------------------------");

    switch (choice)
    {
        case 1:
            Console.Write("Enter Organizer Id: ");

            if (int.TryParse(Console.ReadLine(), out int organizerId))
            {
                service.GetEventsByOrganizer(organizerId);
            }
            else
            {
                Console.WriteLine("Invalid Organizer Id.");
            }

            break;


        case 2:
            Console.Write("Enter Event Id: ");

            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                service.GetAttendeesByEvent(eventId);
            }
            else
            {
                Console.WriteLine("Invalid Event Id.");
            }

            break;


        case 3:
            service.GetTotalRevenuePerEvent();
            break;


        case 4:
            service.GetNumberOfAttendeesPerEvent();
            break;


        case 5:
            service.GetUpcomingEvents();
            break;


        case 6:
            service.GetNotCheckedInAttendees();
            break;


        case 7:
            service.GetMostAttendedEvents();
            break;


        case 8:
            service.GetEventDetails();
            break;


        case 9:
            service.GetMultipleEventsAttendees();
            break;


        case 10:
            service.GetFullyBookedEvents();
            break;


        case 11:
            report.GenerateEventReport();
            break;


        case 12:
            report.AttendeeCheckInReport();
            break;


        default:
            Console.WriteLine("Invalid Choice!");
            break;
    }
}
else
{
    Console.WriteLine("Please enter a valid number.");
}

Console.WriteLine("\n-----------------------------------");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();