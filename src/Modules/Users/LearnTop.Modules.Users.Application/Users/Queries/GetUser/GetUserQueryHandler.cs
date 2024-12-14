using LearnTop.Modules.Users.Application.Users.Dtos;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Application.Users.Queries.GetUser;

public class GetUserQueryHandler
    (IUserViewRepository userViewRepository)
    : IQueryHandler<GetUserQuery, GetUserQueryResponse>
{

    public async Task<Result<GetUserQueryResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        UserView userView = await userViewRepository.GetAsync(request.UserId);

        UserViewDto userViewDto = new(
            userView.Firstname,
            userView.Lastname,
            userView.Email,
            userView.Password
            );

        return new GetUserQueryResponse(userViewDto);
    }
}
