namespace EventManagementSystem.Models;

public class Organizer : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string ContactEmail { get; private set; } = string.Empty;

    public Organizer(int id, string name, string contactEmail)
    {
        Id = id;

        SetName(name);
        SetContactEmail(contactEmail);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Organizer name cannot be empty.");
        }

        Name = name;
    }

    public void SetContactEmail(string contactEmail)
    {
        if (string.IsNullOrWhiteSpace(contactEmail))
        {
            throw new ArgumentException("Contact email cannot be empty.");
        }

        if (!contactEmail.Contains("@"))
        {
            throw new ArgumentException("Invalid contact email.");
        }

        ContactEmail = contactEmail;
    }
}