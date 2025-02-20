using LearnTop.Modules.Ordering.Application.Carts.Features.Commands.ClearCart;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Carts.Endpoints.ClearCart;

internal sealed class ClearCartEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Carts/Items", async ([AsParameters] ClearCartCommand command, ISender sender) =>
        {
            Result<ClearCartResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(Tags.Carts);
    }
}
