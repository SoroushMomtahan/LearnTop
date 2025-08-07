using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Enums;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;

public class Author : Aggregate
{
    public Status Status { get; private set; }
    public string Username { get; private set; }
    public string? DisplayName { get; private set; }
    public long Likes { get; private set; }
    
    private Author(){}

    public static Author Create(Guid userId, string username, string? displayName)
    {
        Author author = new()
        {
            Id = userId,
            Username = username,
            DisplayName = displayName,
            Status = Status.Inactive,
        };
        author.AddDomainEvent(new AuthorCreatedEvent(author));
        return author;
    }
    public void ChangeStatus(Status status)
    {
        Status = status;
        AddDomainEvent(new AuthorUpdatedEvent(this));
    }
    public void AddLike(long like)
    {
        Likes += like;
        AddDomainEvent(new AuthorUpdatedEvent(this));
    }
    public void ChangeDisplayName(string displayName)
    {
        DisplayName = displayName;
        AddDomainEvent(new AuthorUpdatedEvent(this));
    }
    public void ChangeUsername(string username)
    {
        Username = username;
        AddDomainEvent(new AuthorUpdatedEvent(this));
    }
}
