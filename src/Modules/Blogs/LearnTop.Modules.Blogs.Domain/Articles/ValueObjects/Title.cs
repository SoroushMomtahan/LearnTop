using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.ValueObjects;

public record Title : ValueObject<string>
{
    private Title(string value) : base(value)
    {
        if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(ArticleErrors.TitleIsLessThan3Characters());
        }
        if (value.Length > 100)
        {
            throw new DomainException(ArticleErrors.TitleIsGreaterThan100Characters());
        }
    }
    public static implicit operator Title(string value) => new(value);
}
