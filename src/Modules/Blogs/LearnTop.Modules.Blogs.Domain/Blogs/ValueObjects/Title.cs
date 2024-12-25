using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.ValueObjects;

public record Title : ValueObject<string>
{
    private Title(string value) : base(value)
    {
        if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(BlogErrors.TitleIsLessThan3Characters());
        }
        if (value.Length > 100)
        {
            throw new DomainException(BlogErrors.TitleIsGreaterThan100Characters());
        }
    }
    public static implicit operator Title(string value) => new(value);
}
