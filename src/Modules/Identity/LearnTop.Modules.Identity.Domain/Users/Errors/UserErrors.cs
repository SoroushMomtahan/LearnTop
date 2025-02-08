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
    
    public static readonly Error NotFound =
        new(
            "Users.NotFound",
            "کاربری یافت نشد.",
            ErrorType.NotFound);
    public static readonly Error Expired = new(
        "Users.Expired",
        "کد وارد شده منقضی شده است",
        ErrorType.Validation
        );
    public static readonly Error NotValidCode = new(
        "Users.NotValidCode",
        "کد وارد شده معتبر نیست",
        ErrorType.Validation
        );
    public static readonly Error AlreadyVerified = new(
        "Users.AlreadyVerified",
        "شما قبلا احراز هویت شده اید",
        ErrorType.Validation);
}
