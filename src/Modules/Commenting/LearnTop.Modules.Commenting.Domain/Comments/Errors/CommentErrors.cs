using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Domain.Comments.Errors;

public static class CommentErrors
{
    public static Error NotFound(Guid id) => new(
        "Comments.NotFound",
        $"کامنتی با شناسه {id} یافت نشد.",
        ErrorType.NotFound);
    
    public static readonly Error ReplyNotFound = new(
        "Comments.ReplyNotFound",
        "پاسخی یافت نشد.",
        ErrorType.NotFound);
    
    public static readonly Error CommenterNotFound = new(
        "Comments.CommenterNotFound",
        "کاربری با شناسه ارسالی یافت نشد.",
        ErrorType.NotFound);
}
