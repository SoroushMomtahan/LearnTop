using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Events;

public sealed class ArticleDeletedEvent(Article article) : DomainEvent
{
    public Article Article { get; } = article;
}
