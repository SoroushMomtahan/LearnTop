using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Comments.Models;

public class ReplyComment : Entity
{
    public Guid CommentId { get; private set; }
    public Guid ReplierId { get; private set; }
    public string Content { get; private set; }
    private readonly List<Reporter> _reporters = [];
    public IReadOnlyList<Reporter> Reporters => [.. _reporters];
}
