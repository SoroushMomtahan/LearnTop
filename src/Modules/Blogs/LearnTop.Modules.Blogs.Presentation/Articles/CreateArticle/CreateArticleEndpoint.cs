﻿using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

namespace LearnTop.Modules.Blogs.Presentation.Articles.CreateArticle;

internal sealed class CreateArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles", async (CreateArticleCommand command, ISender sender) =>
        {
            Result<CreateArticleResponse> result = await sender.Send(command);
            return result.Match(Results.Created, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
