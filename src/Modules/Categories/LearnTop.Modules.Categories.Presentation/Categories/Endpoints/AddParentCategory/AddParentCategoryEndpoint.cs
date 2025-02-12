using LearnTop.Modules.Categories.Application.Categories.Features.Commands.AddParentCategory;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Categories.Presentation.Categories.Endpoints.AddParentCategory;

internal sealed class AddParentCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Categories/AddParent", async (
            [AsParameters] AddParentCategoryCommand command,
            ISender sender) =>
        {
            Result<AddParentCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
