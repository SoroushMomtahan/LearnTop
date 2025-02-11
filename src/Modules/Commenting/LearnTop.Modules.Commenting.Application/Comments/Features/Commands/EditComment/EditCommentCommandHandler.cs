using LearnTop.Modules.Commenting.Application.Abstractions.Data;
using LearnTop.Modules.Commenting.Domain.Comments.Errors;
using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.EditComment;

internal sealed class EditCommentCommandHandler(
    ICommentRepository commentRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<EditCommentCommand, EditCommentResponse>
{

    public async Task<Result<EditCommentResponse>> Handle(
        EditCommentCommand request, 
        CancellationToken cancellationToken)
    {
        Comment? comment = await commentRepository.GetAsync(request.CommentId, cancellationToken);
        if (comment is null)
        {
            return Result.Failure<EditCommentResponse>(CommentErrors.NotFound(request.CommentId));
        }
        comment.Edit(request.Content);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new EditCommentResponse();
    }
}
