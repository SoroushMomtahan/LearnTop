﻿using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

public class ChangeArticleStatusCommandHandler(IArticleRepository articleRepository)
    : ICommandHandler<ChangeArticleStatusCommand, ChangeArticleStatusResponse>
{

    public async Task<Result<ChangeArticleStatusResponse>> Handle(ChangeArticleStatusCommand request, CancellationToken cancellationToken)
    {
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<ChangeArticleStatusResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        Result result = blog.ChangeStatus(request.Status);
        return result.IsFailure 
            ? Result.Failure<ChangeArticleStatusResponse>(result.Error)
            : new ChangeArticleStatusResponse(blog.Id);
    }
}