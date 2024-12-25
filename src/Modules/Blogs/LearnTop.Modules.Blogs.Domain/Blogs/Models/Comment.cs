using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Models;

public class Comment(Guid commentId, Guid blogId) : Entity
{
    public Guid CommentId { get; private set; } = commentId;
    public Guid BlogId { get; private set; } = blogId;
}
