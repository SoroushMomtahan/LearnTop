using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.DeleteArticle;

internal sealed class SoftDeleteArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Articles/Soft/{id:guid}", async (Guid id, ISender sender) =>
        {
            Result<DeleteArticleResponse> result = await sender.Send(new DeleteArticleCommand(id));
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
