using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Events;

public class TagRemovedEvent(ArticleTag articleTag) : DomainEvent
{
    public ArticleTag ArticleTag { get; } = articleTag;
}
