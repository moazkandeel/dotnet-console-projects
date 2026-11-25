using EventManagementSystem.Data;

namespace EventManagementSystem.Reports;

public class EventReport
{

    // Report: Event Name + Organizer + Venue + Revenue
    public void GenerateEventReport()
    {
        var report =
            from e in FakeData.Events

            join o in FakeData.Organizers
            on e.OrganizerId equals o.Id

            join v in FakeData.Venues
            on e.VenueId equals v.Id

            let revenue = FakeData.Tickets
                .Where(t => t.EventId == e.Id)
                .Sum(t => t.Price)

            select new
            {
                EventName = e.Title,
                Organizer = o.Name,
                Venue = v.Name,
                Revenue = revenue
            };


        foreach (var item in report)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Event: {item.EventName}");
            Console.WriteLine($"Organizer: {item.Organizer}");
            Console.WriteLine($"Venue: {item.Venue}");
            Console.WriteLine($"Revenue: {item.Revenue}");
        }
    }



    // Report: Attendee Check In Status
    public void AttendeeCheckInReport()
    {
        var report =
            from t in FakeData.Tickets

            join a in FakeData.Attendees
            on t.AttendeeId equals a.Id

            join e in FakeData.Events
            on t.EventId equals e.Id

            select new
            {
                Attendee = a.Name,
                Event = e.Title,
                Status = t.CheckedIn ? "Checked In" : "Not Checked"
            };


        foreach (var item in report)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Name: {item.Attendee}");
            Console.WriteLine($"Event: {item.Event}");
            Console.WriteLine($"Status: {item.Status}");
        }
    }

}