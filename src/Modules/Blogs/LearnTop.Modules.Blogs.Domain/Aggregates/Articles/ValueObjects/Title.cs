using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Articles.ValueObjects;

public record Title
{
    public string Value { get; private set; }
    private Title(string value)
    {
        if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException(ArticleErrors.TitleIsLessThan3Characters());
        }
        if (value.Length > 100)
        {
            throw new DomainValidationException(ArticleErrors.TitleIsGreaterThan100Characters());
        }
    }
    public static implicit operator Title(string value) => new(value);
}
