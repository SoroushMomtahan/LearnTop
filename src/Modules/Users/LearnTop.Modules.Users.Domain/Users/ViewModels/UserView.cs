using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.ViewModels;

public class UserView : Entity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserView() { }
}
