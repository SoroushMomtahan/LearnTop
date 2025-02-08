using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.VerifyEmail;

public record VerifyEmailQuery(string Email, int Code) : IQuery<VerifyEmailResponse>;
