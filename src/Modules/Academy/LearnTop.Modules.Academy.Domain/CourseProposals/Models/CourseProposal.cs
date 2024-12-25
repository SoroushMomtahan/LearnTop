using LearnTop.Modules.Academy.Domain.CourseProposals.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.CourseProposals.Models;

public class CourseProposal : Aggregate
{
    public string TitleOfCourse { get; private set; }
    private readonly List<Skill> _skills = [];
    public IReadOnlyList<Skill> Skills => [.. _skills];
    public Guid TeacherId { get; private set; }
    public string Content { get; private set; }
    private readonly List<Liker> _likers = [];
    public IReadOnlyList<Liker> Likers => [.. _likers];

    private CourseProposal() { }

    public static CourseProposal Create(Guid teacherId, string content, string titleOfCourse, List<Skill> skills)
    {
        CourseProposal courseProposal = new()
        {
            TeacherId = teacherId,
            Content = content,
            TitleOfCourse = titleOfCourse
        };
        skills.ForEach(courseProposal.AddSkill);
        courseProposal.AddDomainEvent(new CourseProposalCreatedEvent(courseProposal));
        return courseProposal;
    }
    private void AddSkill(Skill skill)
    {
        _skills.Add(skill);
    }
    public void AddLiker(Liker liker)
    {
        _likers.Add(liker);
    }
}
