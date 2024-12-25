using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Q_A.Models;

public class Question : Aggregate
{
    public Guid CourseId { get; private set; }
    public Guid QuestionerId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
}
