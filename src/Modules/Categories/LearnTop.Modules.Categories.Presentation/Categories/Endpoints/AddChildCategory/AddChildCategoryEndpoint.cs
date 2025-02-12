using LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddChildCategory;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Categories.Presentation.Categories.Endpoints.AddChildCategory;

internal sealed class AddChildCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Categories/AddChild", async (
            AddChildCategoryCommand command, 
            ISender sender) =>
        {
            Result<AddChildCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
