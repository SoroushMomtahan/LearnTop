using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.Errors;

public static class UserErrors
{
    public static Error NotFound(string userId)
    {
        return new("Users.NotFound", $"کاربری با شناسه {userId} یافت نشد.", ErrorType.NotFound);
    }
    public static readonly Error LessThan2Character =
        new("users.LessThan2Character",
            "نام انتخابی باید بیش از 2 کاراکتر باشد",
            ErrorType.Validation);

    public static readonly Error MoreThan20Character =
        new("Users.MoreThan20Character",
            "نام نباید بیش از 20 کاراکتر باشد.",
            ErrorType.Validation);

    public static readonly Error MoreThan50Character =
        new("Users.MoreThan50Character",
            "نام خانوادگی نباید بیش از 50 کاراکتر باشد.",
            ErrorType.Validation);
    public static readonly Error PasswordsNotEqual =
        new("Users.PasswordsNotEqual",
            "کلمه عبور ها با هم برابر نیستند.",
            ErrorType.Validation);
    public static readonly Error EmailNotValid =
        new("Users.EmailNotValid",
            "آدرس ایمیل وارد شده معتبر نمی باشد.",
            ErrorType.Validation);
    public static readonly Error EmailAlreadyExist =
        new("Users.EmailAlreadyExist",
            "ایمیل وارد شده از قبل وجود دارد.",
            ErrorType.Conflict);
    public static Error EmailNotFound(string email)
    {
        return new("users.EmailNotFound",
            $"ایمیل {email} یافت نشد.",
            ErrorType.Validation);
    } 
}
