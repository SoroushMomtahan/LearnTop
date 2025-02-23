using LearnTop.Modules.Ordering.Application.Discounts.Features.Commands.CreateDiscount;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Discounts.Endpoints.CreateDiscount;

internal sealed class CreateDiscountEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Discounts", async (CreateDiscountCommand command, ISender sender) =>
        {
            Result<CreateDiscountResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Discounts);
    }
}
