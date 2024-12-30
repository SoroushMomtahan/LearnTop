using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Models;

public class ArticleTag(Guid tagId, Guid articleId) : Entity
{
    public Guid TagId { get; private set; } = tagId;
    public Guid ArticleId { get; private set; } = articleId;
}
