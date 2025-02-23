using LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.CreateCoupon;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Coupons.Endpoints.CreateCoupon;

internal sealed class CreateCouponEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Coupons", async (CreateCouponCommand command, ISender sender) =>
        {
            Result<CreateCouponResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(Tags.Coupons);
    }
}
