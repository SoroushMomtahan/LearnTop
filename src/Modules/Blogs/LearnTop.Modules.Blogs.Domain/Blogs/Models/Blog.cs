using LearnTop.Modules.Blogs.Domain.Blogs.enums;
using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Events;
using LearnTop.Modules.Blogs.Domain.Blogs.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Models;

public class Blog : Aggregate
{
    public Guid AuthorId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public Status Status { get; private set; }
    public bool IsDeleted { get; private set; }
    private readonly List<Tag> _tags = [];
    public IReadOnlyList<Tag> Tags => [.. _tags];
    
    private Blog() { }

    public static Result<Blog> Create(Guid authorId, Guid categoryId, string title, string content)
    {
        Blog blog = new()
        {
            AuthorId = authorId,
            CategoryId = categoryId,
            Title = title,
            Content = content,
            Status = Status.Confirming
        };
        blog.AddDomainEvent(new BlogCreatedEvent(blog));
        return blog;
    }
    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
        AddDomainEvent(new BlogUpdatedEvent(this));
    }
    public void ChangeCategory(Guid categoryId)
    {
        CategoryId = categoryId;
        AddDomainEvent(new BlogUpdatedEvent(this));
    }
    public Result ChangeStatus(Status status)
    {
        bool isDefined = Enum.IsDefined(status);
        if (!isDefined)
        {
            return Result.Failure(BlogErrors.StatusIsNotInRange());
        }
        Status = status;
        AddDomainEvent(new BlogUpdatedEvent(this));
        return Result.Success();
    }
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
        IsDeleted = true;
        AddDomainEvent(new BlogUpdatedEvent(this));
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
            return Result.Failure(BlogErrors.TagNotFound(tag.TagId));
        }
        _tags.Remove(tag);
        AddDomainEvent(new TagRemovedEvent(tag));
        return Result.Success();
    }
}
