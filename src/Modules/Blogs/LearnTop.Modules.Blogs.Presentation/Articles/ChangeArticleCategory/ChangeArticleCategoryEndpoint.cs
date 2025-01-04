using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

namespace LearnTop.Modules.Blogs.Presentation.Articles.ChangeArticleCategory;

internal sealed class ChangeArticleCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles/Category", async (ChangeArticleCategoryCommand command, ISender sender) =>
        {
            Result<ChangeArticleCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles)
        .RequireAuthorization();
    }
}
