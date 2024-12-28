using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

namespace LearnTop.Modules.Blogs.Presentation.Articles.ChangeArticleStatus;

internal sealed class ChangeArticleStatusEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("Articles/Status", async (ChangeArticleStatusCommand command, ISender sender) =>
        {
            Result<ChangeArticleStatusResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
