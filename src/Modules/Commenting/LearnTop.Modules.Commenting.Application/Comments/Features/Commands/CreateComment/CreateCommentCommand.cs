using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.CreateComment;

public record CreateCommentCommand(
    Guid CommenterId,
    Guid MainPageId,
    Guid? ParentCommentId,
    string Content
    ) : ICommand<CreateCommentResponse>;
