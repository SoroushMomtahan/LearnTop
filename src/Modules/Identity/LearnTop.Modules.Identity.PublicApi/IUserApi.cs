namespace LearnTop.Modules.Identity.PublicApi;

public interface IUserApi
{
    Task<GetUserResponse?> GetAsync(Guid userId);
}

public record GetUserResponse(
    Guid UserId,
    string Username,
    string? Email,
    string? Mobile,
    bool IsBlocked);
