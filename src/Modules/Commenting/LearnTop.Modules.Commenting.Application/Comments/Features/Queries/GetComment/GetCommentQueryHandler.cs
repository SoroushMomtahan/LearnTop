using LearnTop.Modules.Commenting.Application.Comments.Dtos;
using LearnTop.Modules.Commenting.Domain.Comments.Errors;
using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Queries.GetComment;

internal sealed class GetCommentQueryHandler(ICommentRepository commentRepository)
    : IQueryHandler<GetCommentQuery, GetCommentResponse>
{

    public async Task<Result<GetCommentResponse>> Handle(
        GetCommentQuery request,
        CancellationToken cancellationToken)
    {
        Comment? comment = await commentRepository.GetAsync(request.CommentId, cancellationToken);
        if (comment is null)
        {
            return Result.Failure<GetCommentResponse>(CommentErrors.NotFound(request.CommentId));
        }
        CommentDto commentDto = GetCommentDto(comment);
        commentDto.Replies = comment.Replies.Select(GetCommentDto).ToList();
        return new GetCommentResponse(commentDto);
    }
    private static CommentDto GetCommentDto(Comment comment) => new()
    {
        ParentCommentId = comment.ParentCommentId,
        CommenterId = comment.CommenterId,
        MainPageId = comment.MainPageId,
        Content = comment.Content
    };
}
