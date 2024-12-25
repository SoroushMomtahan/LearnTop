using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Comments.Models;

public class Comment : Aggregate
{
    public Guid CommenterId { get; private set; }
    public Guid CourseId { get; private set; }
    public string Content { get; private set; }
    private readonly List<ReplyComment> _replyComments = [];
    public IReadOnlyList<ReplyComment> ReplyComments => [.. _replyComments];
    private readonly List<Reporter> _reporters = [];
    public IReadOnlyList<Reporter> Reporters => [.. _reporters];
}
