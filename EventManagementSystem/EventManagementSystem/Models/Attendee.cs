namespace EventManagementSystem.Models;

public class Attendee : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Attendee(int id, string name, string email)
    {
        Id = id;

        SetName(name);
        SetEmail(email);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Attendee name cannot be empty.");
        }

        Name = name;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Attendee email cannot be empty.");
        }

        if (!email.Contains("@"))
        {
            throw new ArgumentException("Invalid email format.");
        }

        Email = email;
    }
}