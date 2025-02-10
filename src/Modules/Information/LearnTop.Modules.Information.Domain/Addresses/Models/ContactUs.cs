using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Addresses.Models;

public class ContactUs : Entity
{
    public Guid AcademyId { get; private set; }
    public string Fullname { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    private ContactUs() { }
    public static ContactUs Create(string fullname, string email, string phone, string title, string content)
    {
        ContactUs contactUs = new()
        {
            Fullname = fullname,
            Email = email,
            Phone = phone,
            Title = title,
            Content = content
        };
        return contactUs;
    }
}
