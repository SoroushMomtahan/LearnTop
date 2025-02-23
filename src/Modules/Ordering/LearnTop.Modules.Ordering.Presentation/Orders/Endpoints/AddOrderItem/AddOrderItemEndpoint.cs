using LearnTop.Modules.Ordering.Application.Orders.Features.Commands.AddOrderItem;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Orders.Endpoints.AddOrderItem;

internal sealed class AddOrderItemEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Orders/Item", async (AddOrderItemCommand command, ISender sender) =>
        {
            Result<AddOrderItemResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        });
    }
}
