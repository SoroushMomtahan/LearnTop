using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Models;

public class User : Aggregate
{
    public string Username { get; private set; }
    public string? DisplayName { get; private set; }
    public Mobile Mobile { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Guid RefreshToken { get; private set; }
    public DateTime LastLoginDate { get; private set; }
    public bool IsBlocked { get; private set; }

    private readonly List<Role> _roles = [];
    public IReadOnlyList<Role> Roles => [.. _roles];

    private User() { }

    public static Result<User> SignUpWithEmail(string email, string passwordHash)
    {
        User user = new()
        {
            Username = email,
            Email = Email.Create(email),
            PasswordHash = passwordHash
        };
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
    public static Result<User> SignUpWithMobileNumber(string mobileNumber, string passwordHash)
    {
        User user = new()
        {
            Username = mobileNumber,
            Mobile = Mobile.Create(mobileNumber),
            PasswordHash = passwordHash
        };
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
    public Result SignIn(User user)
    {
        if (user.IsBlocked)
        {
            return Result.Failure(UserErrors.WasBlocked);
        }
        if (!user.Email.Verify.Status || !user.Mobile.Verify.Status)
        {
            return Result.Failure(UserErrors.NotVerified);
        }
        LastLoginDate = DateTime.Now;
        AddDomainEvent(new UserUpdatedEvent(this));
        return Result.Success();
    }
    public void ResetPassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        AddDomainEvent(new UserUpdatedEvent(this));
    }
    public void SetRefreshToken(Guid refreshToken)
    {
        RefreshToken = refreshToken;
        AddDomainEvent(new UserUpdatedEvent(this));
    }
}
