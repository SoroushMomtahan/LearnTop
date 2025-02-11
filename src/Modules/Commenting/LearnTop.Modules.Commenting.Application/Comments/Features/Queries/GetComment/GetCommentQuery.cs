using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Queries.GetComment;

public record GetCommentQuery(Guid CommentId) : IQuery<GetCommentResponse>;
