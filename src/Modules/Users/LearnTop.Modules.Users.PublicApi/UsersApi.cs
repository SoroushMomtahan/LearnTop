namespace LearnTop.Modules.Users.PublicApi;

public interface IUsersApi
{
    Task<bool> IsExist(Guid id);
}
