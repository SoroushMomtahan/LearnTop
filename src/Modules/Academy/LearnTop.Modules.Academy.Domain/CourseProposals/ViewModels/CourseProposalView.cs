using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.CourseProposals.ViewModels;

public class CourseProposalView : EntityView
{
    public string TitleOfCourse { get; set; }
    public List<SkillView> Skills { get; set; }
    public Guid TeacherId { get; set; }
    public string Content { get; set; }
    public List<LikerView> Likers { get; set; }
}
