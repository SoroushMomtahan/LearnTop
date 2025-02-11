using LearnTop.Modules.Commenting.Application.Abstractions.Data;
using LearnTop.Modules.Commenting.Domain.Comments.Errors;
using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Modules.Identity.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.CreateComment;

internal sealed class CreateCommentCommandHandler(
    IUserApi userApi,
    ICommentRepository commentRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCommentCommand, CreateCommentResponse>
{

    public async Task<Result<CreateCommentResponse>> Handle(
        CreateCommentCommand request, 
        CancellationToken cancellationToken)
    {
        GetUserResponse? commenter = await userApi.GetAsync(request.CommenterId);
        if (commenter is null)
        {
            return Result.Failure<CreateCommentResponse>(CommentErrors.CommenterNotFound);
        }
        
        var comment = Comment.Create(
            request.Content, 
            request.MainPageId, 
            request.CommenterId, 
            request.ParentCommentId);
        
        if (request.ParentCommentId == null)
        {
            await commentRepository.CreateAsync(comment, cancellationToken);
        }
        else
        {
            Comment? parentComment = await commentRepository.GetAsync(
                request.ParentCommentId.Value, cancellationToken);
            if (parentComment is null)
            {
                return Result.Failure<CreateCommentResponse>(CommentErrors.NotFound(request.ParentCommentId.Value));
            }
            comment.AddReply(comment);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCommentResponse(comment.Id);
    }
}
