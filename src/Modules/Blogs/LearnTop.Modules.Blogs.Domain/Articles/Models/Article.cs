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
    private readonly List<Tag> _tags = [];
    public IReadOnlyList<Tag> Tags => [.. _tags];
    
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
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
        IsDeleted = true;
        AddDomainEvent(new ArticleUpdatedEvent(this));
    }
    public void AddTag(Tag tag)
    {
        bool isExist = _tags.Exists(t=>t.TagId == tag.TagId);
        if (isExist)
        {
            return;
        }
        _tags.Add(tag);
        AddDomainEvent(new TagAddedEvent(tag));
    }
    public Result RemoveTag(Tag tag)
    {
        bool isExist = _tags.Exists(t=>t.TagId == tag.TagId);
        if (!isExist)
        {
            return Result.Failure(ArticleErrors.TagNotFound(tag.TagId));
        }
        _tags.Remove(tag);
        AddDomainEvent(new TagRemovedEvent(tag));
        return Result.Success();
    }
}
