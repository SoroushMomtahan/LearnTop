namespace LearnTop.Modules.Users.PublicApi;

public interface IUsersApi
{
    Task<bool> IsExistAsync(Guid id);
}
