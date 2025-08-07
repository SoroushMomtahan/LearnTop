using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.ChangeArticleCategory;

internal sealed class ChangeArticleCategoryEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/Articles/Category", async (ChangeArticleCategoryCommand command, ISender sender) =>
        {
            Result<ChangeArticleCategoryResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles)
        .RequireAuthorization();
    }
}
