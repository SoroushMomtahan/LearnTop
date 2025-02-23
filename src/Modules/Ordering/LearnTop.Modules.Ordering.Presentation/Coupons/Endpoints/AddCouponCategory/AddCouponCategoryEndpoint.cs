using LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.AddCouponCategory;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Coupons.Endpoints.AddCouponCategory;

internal sealed class AddCouponCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Coupons/AddCategory", async ([AsParameters] AddCouponCategoryCommand command, ISender sender) =>
        {
            Result<AddCouponCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Coupons);
    }
}
