using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Models;

public class User : Aggregate
{
    public string Username { get; private set; }
    public Phone Phone { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime LastLoginDate { get; private set; }
    public bool IsBlocked { get; private set; }

    private User() { }

    public static User SignUpWithEmail(string email, string passwordHash)
    {
        User user = new()
        {
            Username = email,
            Email = email,
            PasswordHash = passwordHash
        };
        return user;
    }
    public static User SignUpWithPhone(string phoneNumber, string passwordHash)
    {
        User user = new()
        {
            Username = phoneNumber,
            Phone = phoneNumber,
            PasswordHash = passwordHash
        };
        return user;
    }
    public Result SignIn(User user)
    {
        if (user.IsBlocked)
        {
            return Result.Failure(UserErrors.WasBlocked);
        }
        if (!user.Email.EmailVerified || !user.Phone.PhoneNumberVerified)
        {
            return Result.Failure(UserErrors.NotVerified);
        }
        LastLoginDate = DateTime.Now;
        return Result.Success();
    }
    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
        Email.EmailVerified = false;
        UpdatedAt = DateTime.Now;
    }
    public void SetEmailVerifyCode(int code)
    {
        Email.EmailVerifyCode = code;
    }
    public void SetPhoneNumberVerifyCode(int code)
    {
        Phone.PhoneNumberVerifyCode = code;
    }
    public void SetEmailVerified(bool verified)
    {
        Email.EmailVerified = verified;
    }
    public void SetPhoneNumberVerified(bool verified)
    {
        Phone.PhoneNumberVerified = verified;
    }
}
