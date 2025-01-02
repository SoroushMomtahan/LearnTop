using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.ConfirmEmail;

public record ConfirmEmailQuery(string UserId, string EmailAddress, string Code)
    : IQuery<ConfirmEmailResponse>;
