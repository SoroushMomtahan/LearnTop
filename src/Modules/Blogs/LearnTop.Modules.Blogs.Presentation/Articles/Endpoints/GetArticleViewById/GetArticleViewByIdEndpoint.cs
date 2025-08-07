using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViewById;

internal sealed class GetArticleViewByIdEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/{articleId:guid}", async (Guid articleId, ISender sender) =>
        {
            Result<GetArticleViewByIdResponse> result = await sender.Send(
                new GetArticleViewByIdQuery(articleId)
                );
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
