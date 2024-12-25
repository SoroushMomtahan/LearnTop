using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.ViewModels;

public class AcademyInfoView : EntityView
{
    public string Fullname { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
