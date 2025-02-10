using LearnTop.Modules.Commenting.Domain.Comments.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Domain.Comments.Models;

public class Comment : Aggregate
{
    public string Content { get; private set; }
    public Comment MainComment { get; private set; }
    private readonly List<Comment> _replies = [];
    public IReadOnlyList<Comment> Replies => _replies;
    public Guid? ParentCommentId { get; private set; }
    
    private Comment(){ }
    public static Comment Create(string content, Guid parentCommentId = default)
    {
        return new()
        {
            Content = content,
            ParentCommentId = parentCommentId
        };
    }
    public void AddReply(Comment comment)
    {
        if (_replies.Contains(comment))
        {
            return;
        }
        _replies.Add(comment);
    }
    public Result DeleteReply(Comment comment)
    {
        if (!_replies.Contains(comment))
        {
            return Result.Failure(CommentErrors.ReplyNotFound);
        }
        _replies.Remove(comment);
        return Result.Success();
    }
}
