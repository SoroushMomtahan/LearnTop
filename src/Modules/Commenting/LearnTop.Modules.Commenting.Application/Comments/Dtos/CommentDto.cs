namespace LearnTop.Modules.Commenting.Application.Comments.Dtos;

public record CommentDto
{
    public Guid CommenterId { get; set; }
    public Guid MainPageId { get; set; }
    public string Content { get; set; }
    public IReadOnlyList<CommentDto> Replies { get; set; }
    public Guid? ParentCommentId { get; set; }
}
