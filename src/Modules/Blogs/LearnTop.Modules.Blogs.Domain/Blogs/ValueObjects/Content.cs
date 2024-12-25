using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.ValueObjects;

public record Content : ValueObject<string>
{
    private Content(string value) : base(value)
    {
        if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(BlogErrors.ContentIsLessThan3Characters());
        }
    }
    public static implicit operator Content(string value) => new(value);
    public static implicit operator string(Content content) => content.Value;
}
