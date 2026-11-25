using EventManagementSystem.Data;

namespace EventManagementSystem.Services;

public class EventService
{

    // 1- Get all events organized by a specific organizer
    public void GetEventsByOrganizer(int organizerId)
    {
        var result = FakeData.Events
            .Where(e => e.OrganizerId == organizerId);

        foreach (var e in result)
        {
            Console.WriteLine(e.Title);
        }
    }


    // 2- Get all attendees for a specific event
    public void GetAttendeesByEvent(int eventId)
    {
        var result =
            from ticket in FakeData.Tickets
            join attendee in FakeData.Attendees
            on ticket.AttendeeId equals attendee.Id
            where ticket.EventId == eventId
            select attendee;

        foreach (var a in result)
        {
            Console.WriteLine(a.Name);
        }
    }


    // 3- Total ticket revenue per event
    public void GetTotalRevenuePerEvent()
    {
        var result = FakeData.Tickets
            .GroupBy(t => t.EventId)
            .Select(g => new
            {
                EventId = g.Key,
                Revenue = g.Sum(t => t.Price)
            });


        foreach (var item in result)
        {
            Console.WriteLine(
                $"Event Id: {item.EventId} Revenue: {item.Revenue}"
            );
        }
    }


    // 4- Number of attendees per event
    public void GetNumberOfAttendeesPerEvent()
    {
        var result = FakeData.Tickets
            .GroupBy(t => t.EventId)
            .Select(g => new
            {
                EventId = g.Key,
                Count = g.Count()
            });


        foreach (var item in result)
        {
            Console.WriteLine(
                $"Event {item.EventId} Attendees {item.Count}"
            );
        }
    }


    // 5- Upcoming events sorted by date
    public void GetUpcomingEvents()
    {
        var result = FakeData.Events
            .Where(e => e.EventDate > DateTime.Now)
            .OrderBy(e => e.EventDate);


        foreach (var e in result)
        {
            Console.WriteLine(
                $"{e.Title} - {e.EventDate}"
            );
        }
    }


    // 6- Attendees who didn’t check in
    public void GetNotCheckedInAttendees()
    {
        var result =
            from ticket in FakeData.Tickets
            join attendee in FakeData.Attendees
            on ticket.AttendeeId equals attendee.Id
            where ticket.CheckedIn == false
            select attendee;


        foreach (var a in result)
        {
            Console.WriteLine(a.Name);
        }
    }


    // 7- Most attended events
    public void GetMostAttendedEvents()
    {
        var result = FakeData.Tickets
            .GroupBy(t => t.EventId)
            .OrderByDescending(g => g.Count());


        foreach (var e in result)
        {
            Console.WriteLine(
                $"Event Id: {e.Key} Count: {e.Count()}"
            );
        }
    }


    // 8- Event with organizer and venue info
    public void GetEventDetails()
    {
        var result =
            from e in FakeData.Events

            join o in FakeData.Organizers
            on e.OrganizerId equals o.Id

            join v in FakeData.Venues
            on e.VenueId equals v.Id

            select new
            {
                Event = e.Title,
                Organizer = o.Name,
                Venue = v.Name
            };


        foreach (var item in result)
        {
            Console.WriteLine(
                $"{item.Event} - {item.Organizer} - {item.Venue}"
            );
        }
    }


    // 9- Attendees attending multiple events
    public void GetMultipleEventsAttendees()
    {
        var result = FakeData.Tickets
            .GroupBy(t => t.AttendeeId)
            .Where(g => g.Select(x => x.EventId)
            .Distinct()
            .Count() > 1);


        foreach (var item in result)
        {
            Console.WriteLine(
                $"Attendee Id {item.Key}"
            );
        }
    }


    // 10- Events that are fully booked
    public void GetFullyBookedEvents()
    {
        var result =
            from e in FakeData.Events

            join v in FakeData.Venues
            on e.VenueId equals v.Id

            let attendeesCount = FakeData.Tickets
                .Count(t => t.EventId == e.Id)

            where attendeesCount >= v.Capacity

            select e;


        foreach (var e in result)
        {
            Console.WriteLine(e.Title);
        }
    }

}