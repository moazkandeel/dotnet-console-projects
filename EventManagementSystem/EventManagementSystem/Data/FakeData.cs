using EventManagementSystem.Models;

namespace EventManagementSystem.Data;

public static class FakeData
{
    public static List<Organizer> Organizers = new()
    {
        new Organizer(
            1,
            "Maoz",
            "maoz@gmail.com"
        ),

        new Organizer(
            2,
            "Microsoft",
            "microsoft@gmail.com"
        )
    };

    public static List<Venue> Venues = new()
    {
        new Venue(
            1,
            "Cairo Hall",
            "Nasr City",
            500
        ),

        new Venue(
            2,
            "Opera House",
            "Downtown",
            300
        )
    };

    public static List<Attendee> Attendees = new()
    {
        new Attendee(
            1,
            "Mo",
            "mo@gmail.com"
        ),

        new Attendee(
            2,
            "Ali",
            "ali@gmail.com"
        ),

        new Attendee(
            3,
            "Omar",
            "omar@gmail.com"
        )
    };

    public static List<Event> Events = new()
    {
        new Event(
            1,
            "AI Conference",
            1,
            1,
            new DateTime(2026, 9, 10)
        ),

        new Event(
            2,
            "C# Bootcamp",
            2,
            2,
            new DateTime(2026, 10, 15)
        )
    };

    public static List<Ticket> Tickets = new()
    {
        new Ticket(
            1,
            1,
            1,
            300,
            true
        ),

        new Ticket(
            2,
            1,
            2,
            300,
            false
        ),

        new Ticket(
            3,
            2,
            3,
            500,
            true
        )
    };
}