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
    public bool IsDelete { get; private set; }
    private readonly List<Tag> _tags = [];
    public IReadOnlyList<Tag> Tags => [.. _tags];
    private readonly List<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => [.. _comments];
    
    private Blog() { }

    public static Result<Blog> Create(Guid authorId, string title, string content)
    {
        Blog blog = new()
        {
            AuthorId = authorId,
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
    public void ChangeStatus(Status status)
    {
        Status = status;
        AddDomainEvent(new BlogCreatedEvent(this));
    }
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
        IsDelete = true;
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
    public void AddComment(Comment comment)
    {
        bool isExist = _comments.Exists(c => c.CommentId == comment.CommentId);
        if (isExist)
        {
            return;
        }
        _comments.Add(comment);
        AddDomainEvent(new CommentAddedEvent(comment));
    }
    public Result RemoveComment(Comment comment)
    {
        bool isExist = _comments.Exists(c => c.CommentId == comment.CommentId);
        if (!isExist)
        {
            Result.Failure(BlogErrors.TagNotFound(comment.CommentId));
        }
        _comments.Remove(comment);
        AddDomainEvent(new CommentRemovedEvent(comment));
        return Result.Success();
    }
}
