using LearnTop.Modules.Users.Application.Users.Dtos;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler
    (IUserViewRepository userViewRepository)
    : IQueryHandler<GetUsersQuery, GetUsersQueryResponse>
{

    public async Task<Result<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;

        IEnumerable<UserView> userViews = await userViewRepository.GetAllAsync(pageIndex, pageSize);

        int totalCount = await userViewRepository.GetCountAsync();

        IEnumerable<UserViewDto> userViewDtos = userViews.Select(u =>
                new UserViewDto(u.Firstname, u.Lastname, u.Email, u.Password)
            ).ToList();

        var getUserQueryResponse = new GetUsersQueryResponse(
            new(pageIndex, pageSize, totalCount, userViewDtos));

        return getUserQueryResponse;
    }
}
