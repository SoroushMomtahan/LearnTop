using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.DeleteComment;

public record DeleteCommentCommand(Guid CommentId) : ICommand<DeleteCommentResponse>;
