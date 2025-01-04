using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;
using Microsoft.AspNetCore.Mvc;


namespace LearnTop.Modules.Blogs.Presentation.Articles.AddArticleTag;

internal sealed class AddArticleTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles/Tag", async (AddArticleTagCommand articleTagCommand, ISender sender) =>
            {
                Result<AddArticleTagResponse> result = await sender.Send(articleTagCommand);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles)
            .RequireAuthorization();
    }
}
