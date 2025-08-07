using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Events;

public sealed class ArticleUpdatedEvent(Article article) : DomainEvent
{
    public Article Article { get; } = article;
}
