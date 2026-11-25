namespace EventManagementSystem.Models;

public class Venue : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public int Capacity { get; private set; }

    public Venue(int id, string name, string location, int capacity)
    {
        Id = id;

        SetName(name);
        SetLocation(location);
        SetCapacity(capacity);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Venue name cannot be empty.");
        }

        Name = name;
    }

    public void SetLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Venue location cannot be empty.");
        }

        Location = location;
    }

    public void SetCapacity(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Venue capacity must be greater than zero.");
        }

        Capacity = capacity;
    }
}