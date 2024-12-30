using System.Security.Claims;
using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;
using LearnTop.Modules.Blogs.Domain.Articles.Views;

namespace LearnTop.Modules.Blogs.Presentation.Articles.UpdateOwnArticle;

internal sealed class UpdateOwnArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles/Own", async (
            UpdateArticleCommand command, 
            ClaimsPrincipal claimsPrincipal,
            ISender sender) =>
        {
            Result<GetArticleViewByIdResponse> foundedArticleResult = await sender.Send(new GetArticleViewByIdQuery(command.ArticleId));
            if (foundedArticleResult.IsFailure)
            {
                return ApiResults.Problem(foundedArticleResult);
            }
            Result<UpdateArticleResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
