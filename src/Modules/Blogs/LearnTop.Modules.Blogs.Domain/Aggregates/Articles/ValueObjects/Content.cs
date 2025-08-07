using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Articles.ValueObjects;

public record Content
{
    public string Value { get; private set; }
    private Content(string value)
    {
        if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException(ArticleErrors.ContentIsLessThan3Characters());
        }
    }
    public static implicit operator Content(string value) => new(value);
    public static implicit operator string(Content value) => value.ToString();
}
