namespace EventManagementSystem.Models;

public class Event : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public int OrganizerId { get; private set; }
    public int VenueId { get; private set; }
    public DateTime EventDate { get; private set; }

    public Event(int id, string title, int organizerId, int venueId, DateTime eventDate)
    {
        Id = id;

        SetTitle(title);
        SetOrganizerId(organizerId);
        SetVenueId(venueId);
        SetEventDate(eventDate);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title cannot be empty.");
        }

        Title = title;
    }

    public void SetOrganizerId(int organizerId)
    {
        if (organizerId <= 0)
        {
            throw new ArgumentException("Organizer Id must be greater than zero.");
        }

        OrganizerId = organizerId;
    }

    public void SetVenueId(int venueId)
    {
        if (venueId <= 0)
        {
            throw new ArgumentException("Venue Id must be greater than zero.");
        }

        VenueId = venueId;
    }

    public void SetEventDate(DateTime eventDate)
    {
        if (eventDate <= DateTime.Now)
        {
            throw new ArgumentException("Event date must be in the future.");
        }

        EventDate = eventDate;
    }
}