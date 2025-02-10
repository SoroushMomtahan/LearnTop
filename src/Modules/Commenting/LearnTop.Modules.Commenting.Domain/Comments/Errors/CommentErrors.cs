using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Domain.Comments.Errors;

public static class CommentErrors
{
    public static readonly Error NotFound = new(
        "Comments.NotFound",
        "کامنتی یافت نشد.",
        ErrorType.NotFound);
    
    public static readonly Error ReplyNotFound = new(
        "Comments.ReplyNotFound",
        "پاسخی یافت نشد.",
        ErrorType.NotFound);
}
