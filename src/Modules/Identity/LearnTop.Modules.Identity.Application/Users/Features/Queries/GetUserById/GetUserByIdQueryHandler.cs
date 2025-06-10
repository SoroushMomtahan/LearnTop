using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserById;

internal sealed class GetUserByIdQueryHandler
    (IUserRepository userRepository) 
    : IQueryHandler<GetUserByIdQuery, GetUserByIdQuery.Response>
{

    public async Task<Result<GetUserByIdQuery.Response>> Handle(
        GetUserByIdQuery request, 
        CancellationToken cancellationToken)
    {
        User user = await userRepository.GetUserAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<GetUserByIdQuery.Response>(UserErrors.NotFound);
        }
        return new GetUserByIdQuery.Response(user);
    }
}
