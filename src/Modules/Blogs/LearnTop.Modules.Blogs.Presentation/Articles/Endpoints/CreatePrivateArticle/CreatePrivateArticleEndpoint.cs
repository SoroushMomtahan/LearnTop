using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreatePrivateArticle;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.CreatePrivateArticle;

internal sealed class CreatePrivateArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/PrivateArticle/{authorId:guid}", async (Guid authorId, ISender sender) =>
        {
            Result<CreatePrivateArticleCommand.Response> result = await sender.Send(new CreatePrivateArticleCommand(authorId));
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
