using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Errors;

public static class UserErrors
{
    public static readonly Error NotVerified =
        new(
            "Users.NotVerified",
            "شماره ایمیل یا موبایل تایید نشده است.",
            ErrorType.Validation);
    
    public static readonly Error WasBlocked =
        new(
            "Users.WasBlocked",
            "اکانت شما مسدود می باشد.",
            ErrorType.Validation);
}
