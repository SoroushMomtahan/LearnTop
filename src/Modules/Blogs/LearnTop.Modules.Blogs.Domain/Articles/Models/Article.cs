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
    public string CoverName { get; private set; }
    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public ShortContent ShortContent { get; private set; }
    public Status Status { get; private set; }
    public bool IsDeleted { get; private set; }
    private readonly List<Guid> _tagIds = [];
    public IReadOnlyList<Guid> TagIds => [.. _tagIds];
    
    private Article() { }

    public static Result<Article> Create(
        Guid authorId, 
        Guid categoryId, 
        string coverName,
        string title, 
        string shortContent, 
        string content)
    {
        Article article = new()
        {
            AuthorId = authorId,
            CategoryId = categoryId,
            CoverName = coverName,
            Title = title,
            Content = content,
            Status = Status.Confirming,
            ShortContent = shortContent,
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
    public void AddTag(Guid tagId)
    {
        bool isExist = _tagIds.Contains(tagId);
        if (isExist)
        {
            return;
        }
        _tagIds.Add(tagId);
        AddDomainEvent(new ArticleUpdatedEvent(this));
    }
    public Result RemoveTag(Guid tagId)
    {
        bool isExist = _tagIds.Contains(tagId);
        if (!isExist)
        {
            return Result.Failure(ArticleErrors.TagNotFound(tagId));
        }
        _tagIds.Remove(tagId);
        AddDomainEvent(new ArticleUpdatedEvent(this));
        return Result.Success();
    }
}
