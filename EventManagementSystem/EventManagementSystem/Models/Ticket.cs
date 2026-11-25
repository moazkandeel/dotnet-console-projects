namespace EventManagementSystem.Models;

public class Ticket : BaseEntity
{
    public int EventId { get; private set; }
    public int AttendeeId { get; private set; }
    public decimal Price { get; private set; }
    public bool CheckedIn { get; private set; }

    public Ticket(
        int id,
        int eventId,
        int attendeeId,
        decimal price,
        bool checkedIn)
    {
        Id = id;

        SetEventId(eventId);
        SetAttendeeId(attendeeId);
        SetPrice(price);

        CheckedIn = checkedIn;
    }

    public void SetEventId(int eventId)
    {
        if (eventId <= 0)
        {
            throw new ArgumentException("Event Id must be greater than zero.");
        }

        EventId = eventId;
    }

    public void SetAttendeeId(int attendeeId)
    {
        if (attendeeId <= 0)
        {
            throw new ArgumentException("Attendee Id must be greater than zero.");
        }

        AttendeeId = attendeeId;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Ticket price cannot be negative.");
        }

        Price = price;
    }

    public void CheckIn()
    {
        CheckedIn = true;
    }
}