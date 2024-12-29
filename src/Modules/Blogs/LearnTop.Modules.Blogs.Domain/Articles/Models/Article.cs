using LearnTop.Modules.Blogs.Domain.Articles.enums;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Models;

public class Article : Aggregate
{
    public Guid AuthorId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public Status Status { get; private set; }
    public bool IsDeleted { get; private set; }
    private readonly List<ArticleTag> _tags = [];
    public IReadOnlyList<ArticleTag> Tags => [.. _tags];
    
    private Article() { }

    public static Result<Article> Create(Guid authorId, Guid categoryId, string title, string content)
    {
        Article article = new()
        {
            AuthorId = authorId,
            CategoryId = categoryId,
            Title = title,
            Content = content,
            Status = Status.Confirming
        };
        article.AddDomainEvent(new ArticleCreatedEvent(article));
        return article;
    }
    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
        AddDomainEvent(new ArticleUpdatedEvent(this));
    }
    public void ChangeCategory(Guid categoryId)
    {
        CategoryId = categoryId;
        AddDomainEvent(new ArticleUpdatedEvent(this));
    }
    public Result ChangeStatus(Status status)
    {
        bool isDefined = Enum.IsDefined(status);
        if (!isDefined)
        {
            return Result.Failure(ArticleErrors.StatusIsNotInRange());
        }
        Status = status;
        AddDomainEvent(new ArticleUpdatedEvent(this));
        return Result.Success();
    }
    public void SoftDelete()
    {
        DeletedAt = DateTime.Now;
        IsDeleted = true;
        AddDomainEvent(new ArticleUpdatedEvent(this));
    }
    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        AddDomainEvent(new ArticleDeletedEvent(this));
    }
    public void AddTag(ArticleTag articleTag)
    {
        bool isExist = _tags.Exists(t=>t.TagId == articleTag.TagId && t.ArticleId == articleTag.ArticleId);
        if (isExist)
        {
            return;
        }
        _tags.Add(articleTag);
        AddDomainEvent(new TagAddedEvent(articleTag));
    }
    public Result RemoveTag(ArticleTag articleTag)
    {
        bool isExist = _tags.Exists(t=>t.TagId == articleTag.TagId && t.ArticleId == articleTag.ArticleId);
        if (!isExist)
        {
            return Result.Failure(ArticleErrors.TagNotFound(articleTag.TagId));
        }
        _tags.Remove(articleTag);
        AddDomainEvent(new TagRemovedEvent(articleTag));
        return Result.Success();
    }
}
