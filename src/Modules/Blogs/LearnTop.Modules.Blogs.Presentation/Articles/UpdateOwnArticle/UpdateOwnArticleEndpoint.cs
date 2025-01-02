using System.Security.Claims;
using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using Serilog;

namespace LearnTop.Modules.Blogs.Presentation.Articles.UpdateOwnArticle;

internal sealed class UpdateOwnArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/OwnArticle", async (
                UpdateArticleCommand command,
                ClaimsPrincipal user,
                ISender sender) =>
            {
                string? userId = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                
                Result<GetArticleViewByIdResponse> foundedArticleResult =
                    await sender.Send(new GetArticleViewByIdQuery(command.ArticleId));
                if (foundedArticleResult.IsFailure)
                {
                    return ApiResults.Problem(foundedArticleResult);
                }
                if (userId is null || foundedArticleResult.Value.ArticleView.AuthorId != Guid.Parse(userId))
                {
                    return Results.Unauthorized();
                }
                Result<UpdateArticleResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles)
            .RequireAuthorization();
    }
}
