using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.ViewModels;

public class ContactUsView : EntityView
{
    public Guid AcademyId { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
