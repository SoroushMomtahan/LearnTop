namespace LearnTop.Modules.Users.Application.Users.Features.Queries.SignIn;

public record SignInResponse(
    string AccessToken,
    string RefreshToken);
