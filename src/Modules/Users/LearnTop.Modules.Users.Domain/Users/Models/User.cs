using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Modules.Users.Domain.Users.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.Models;

public class User : Aggregate
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User() { }

    public static Result<User> Create(string firstname, string lastname, string email, string password)
    {
        if (firstname.Length < 3)
        {
            return Result.Failure<User>(UserErrors.LessThan3Character);
        }
        User user = new()
        {
            Firstname = firstname,
            Lastname = lastname,
            Email = email,
            Password = password
        };
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
}
