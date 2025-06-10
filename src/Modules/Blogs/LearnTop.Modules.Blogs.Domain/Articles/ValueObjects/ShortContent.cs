using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.ValueObjects;

public record ShortContent
{
    public string Value { get; private set; }
    public ShortContent(string value)
    {
        if (value.Length is > 100 or < 3 )
        {
            throw new DomainValidationException(ArticleErrors.ShortContentOutOfRange());
        }
        Value = value;
    }
    public static implicit operator ShortContent(string value) => new(value);
}
