using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.ConfirmEmail;

internal sealed class ConfirmEmailQueryHandler
    (UserManager<IdentityUser> userManager)
    : IQueryHandler<ConfirmEmailQuery, ConfirmEmailResponse>
{

    public async Task<Result<ConfirmEmailResponse>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await userManager.FindByIdAsync(request.UserId.ToString());
        if (identityUser is null)
        {
            return Result.Failure<ConfirmEmailResponse>(UserErrors.NotFound(request.UserId));
        }
        IdentityResult identityResult = await userManager.ConfirmEmailAsync(identityUser, request.Code);
        if (!identityResult.Succeeded)
        {
            Error[] errors = identityResult.Errors.Select(e => Error.Problem(e.Code, e.Description)).ToArray();
            return Result.Failure<ConfirmEmailResponse>(new ValidationError(errors));
        }
        return new ConfirmEmailResponse(request.UserId.ToString());
    }
}
