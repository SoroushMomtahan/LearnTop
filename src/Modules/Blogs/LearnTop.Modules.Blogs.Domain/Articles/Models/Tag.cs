using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Models;

public class Tag(Guid tagId, Guid blogId) : Entity
{
    public Guid TagId { get; private set; } = tagId;
    public Guid BlogId { get; private set; } = blogId;
    public Article Article { get; private set; }
}
