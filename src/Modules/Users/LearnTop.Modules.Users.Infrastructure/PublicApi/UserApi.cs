using LearnTop.Modules.Users.Application.Users.Features.Queries.GetUserById;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Modules.Users.Infrastructure.PublicApi;

internal sealed class UsersApi
    (ISender sender)
    : IUsersApi
{

    public async Task<bool> IsExistAsync(Guid id)
    {
        Result<GetUserByIdResponse> result = await sender.Send(new GetUserByIdQuery(id));
        return !result.IsFailure;
    }
}
