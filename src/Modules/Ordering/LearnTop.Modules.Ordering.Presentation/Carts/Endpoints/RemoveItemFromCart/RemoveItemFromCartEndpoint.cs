using LearnTop.Modules.Ordering.Application.Carts.Features.Commands.RemoveItemFromCart;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Carts.Endpoints.RemoveItemFromCart;

internal sealed class RemoveItemFromCartEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Carts/Item", async (
            [AsParameters] RemoveItemFromCartCommand command, 
            ISender sender) =>
        {
            Result<RemoveItemFromCartResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Carts);
    }
}
