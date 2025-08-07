using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.ChangeArticleStatus;

internal sealed class ChangeArticleStatusEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("Articles/Status", async (ChangeArticleStatusCommand command, ISender sender) =>
        {
            Result<ChangeArticleStatusResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles)
        .RequireAuthorization();
    }
}
