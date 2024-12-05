using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.Errors;

public static class UserErrors
{
    public static readonly Error LessThan3Character =
        new("users.domain",
            "نام باید بیش از 3 کاراکتر باشد",
            ErrorType.Validation);
}
