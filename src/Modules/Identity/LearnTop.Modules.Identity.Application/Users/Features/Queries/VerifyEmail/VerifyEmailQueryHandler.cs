using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.VerifyEmail;

internal sealed class VerifyEmailQueryHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) 
    : IQueryHandler<VerifyEmailQuery, VerifyEmailResponse>
{

    public async Task<Result<VerifyEmailResponse>> Handle(VerifyEmailQuery request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetUserAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<VerifyEmailResponse>(UserErrors.NotFound);
        }
        if (user.Email.Verify.Code != request.Code)
        {
            return Result.Failure<VerifyEmailResponse>(UserErrors.NotValidCode);
        }
        if (user.Email.Verify.ExpireIn < DateTime.Now)
        {
            return Result.Failure<VerifyEmailResponse>(UserErrors.Expired);
        }
        user.Email.ChangeVerifyStatus();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new VerifyEmailResponse();
    }
}
