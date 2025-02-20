using LearnTop.Modules.Ordering.Application.Carts.Features.Commands.AddItemToCart;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Ordering.Presentation.Carts.Endpoints.AddItemToCart;

internal sealed class AddItemToCartEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Carts", async (AddItemToCartCommand command, ISender sender) =>
        {
            Result<AddItemToCartResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Carts);
    }
}
