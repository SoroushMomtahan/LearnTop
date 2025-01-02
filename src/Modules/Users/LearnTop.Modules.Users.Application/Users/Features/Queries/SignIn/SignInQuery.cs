using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.SignIn;

public record SignInQuery(string Email, string Password) : IQuery<SignInResponse>;
