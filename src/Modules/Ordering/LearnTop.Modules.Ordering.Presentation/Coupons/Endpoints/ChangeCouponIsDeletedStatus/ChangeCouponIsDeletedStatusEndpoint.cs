using LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.ChangeCouponIsDeletedStatus;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Coupons.Endpoints.ChangeCouponIsDeletedStatus;

internal sealed class ChangeCouponIsDeletedStatusEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Coupons/DeleteStatus", async (
            [AsParameters] ChangeCouponIsDeletedStatusCommand command,
            ISender sender) =>
        {
            Result<ChangeCouponIsDeletedStatusResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Coupons);
    }
}
