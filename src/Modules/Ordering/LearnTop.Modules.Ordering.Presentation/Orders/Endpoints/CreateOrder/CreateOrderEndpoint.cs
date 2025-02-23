using LearnTop.Modules.Ordering.Application.Orders.Features.Commands.CreateOrder;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Orders.Endpoints.CreateOrder;

internal sealed class CreateOrderEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Orders", async (
            [AsParameters] CreateOrderCommand command,
            ISender sender) =>
        {
            Result<CreateOrderResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Orders);
    }
}
