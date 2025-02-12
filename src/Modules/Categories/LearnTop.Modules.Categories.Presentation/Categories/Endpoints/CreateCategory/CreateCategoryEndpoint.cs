using LearnTop.Modules.Categories.Application.Categories.Features.Commands.CreateCategory;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Categories.Presentation.Categories.Endpoints.CreateCategory;

internal sealed class CreateCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Categories", async (CreateCategoryCommand command, ISender sender) =>
        {
            Result<CreateCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
