using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Q_A.Models;

public class Answer : Entity
{
    public Guid QuestionId { get; private set; }
    public Guid AnswerId { get; private set; }
    public string Content { get; private set; }
}
