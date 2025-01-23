using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Modules.Users.Domain.Users.Events;
using LearnTop.Modules.Users.Domain.Users.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.Models;

public class User : Aggregate
{
    public string Fullname { get; private set; }
    public Firstname Firstname { get; private set; }
    public Lastname Lastname { get; private set; }
    public Guid IdentityUser { get; private set; }

    #pragma warning disable S125
    // public DateTime LastLoginDate { get; private set; }

    private User() { }

    public static Result<User> Create(string firstname, string lastname, Guid identityUser)
    {
        User user = new()
        {
            Firstname = firstname,
            Lastname = lastname,
            IdentityUser = identityUser,
            Fullname = $"{firstname} {lastname}",
        };
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
    public static Result<User> Create(Guid identityUser)
    {
        User user = new()
        {
            IdentityUser = identityUser,
        };
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
}
