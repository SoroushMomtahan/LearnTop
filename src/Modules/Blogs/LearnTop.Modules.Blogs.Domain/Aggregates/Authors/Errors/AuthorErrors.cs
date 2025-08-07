using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Errors;

public static class AuthorErrors
{
    public static Error NotFound(Guid authorId)
    {
        return new(
            "Author.NotFound", 
            $"کاربری با شناسه {authorId} یافت نشد", 
            ErrorType.NotFound);
    }
}
