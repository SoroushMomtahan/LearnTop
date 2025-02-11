using LearnTop.Modules.Commenting.Application.Abstractions.Data;
using LearnTop.Modules.Commenting.Domain.Comments.Errors;
using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.DeleteComment;

internal sealed class DeleteCommentCommandHandler(
    ICommentRepository commentRepository, 
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCommentCommand, DeleteCommentResponse>
{

    public async Task<Result<DeleteCommentResponse>> Handle(
        DeleteCommentCommand request, 
        CancellationToken cancellationToken)
    {
        Comment? comment = await commentRepository.GetAsync(request.CommentId, cancellationToken);
        if (comment is null)
        {
            return Result.Failure<DeleteCommentResponse>(CommentErrors.NotFound(request.CommentId));
        }
        commentRepository.Delete(comment);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteCommentResponse(true);
    }
}
