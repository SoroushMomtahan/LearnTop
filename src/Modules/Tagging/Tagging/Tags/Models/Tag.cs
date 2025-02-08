using LearnTop.Shared.Domain;

namespace Tagging.Tags.Models;

public sealed class Tag : Aggregate
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }

    private Tag() {}
    public static Result<Tag> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Tag>(Errors.TagErrors.TitleIsEmpty);
        }
        if (description.Length < 3)
        {
            return Result.Failure<Tag>(Errors.TagErrors.DescriptionLessThan3Character);
        }
        Tag tag = new()
        {
            Title = Tagify(title),
            Description = description
        };
        tag.AddDomainEvent(new Events.TagCreatedEvent(tag));
        return tag;
    }
    public Result Update(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Tag>(Errors.TagErrors.TitleIsEmpty);
        }
        if (description.Length < 3)
        {
            return Result.Failure(Errors.TagErrors.DescriptionLessThan3Character);
        }
        Title = Tagify(title);
        Description = description;
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new Events.TagUpdatedEvent(this));
        return Result.Success();
    }
    public void SoftDelete()
    {
        DeletedAt = DateTime.Now;
        IsDeleted = true;
        AddDomainEvent(new Events.TagUpdatedEvent(this));
    }
    private static string Tagify(string title)
    {
        return title
            .StartsWith('#') ? $"{title}" : $"#{title}"
            .Replace(' ', '_');
    }
}
