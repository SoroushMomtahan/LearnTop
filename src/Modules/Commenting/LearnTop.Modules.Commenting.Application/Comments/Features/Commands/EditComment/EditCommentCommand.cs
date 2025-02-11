using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.EditComment;

public record EditCommentCommand(Guid CommentId, string Content) : ICommand<EditCommentResponse>;
