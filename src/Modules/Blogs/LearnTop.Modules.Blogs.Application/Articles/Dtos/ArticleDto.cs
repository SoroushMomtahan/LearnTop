namespace LearnTop.Modules.Blogs.Application.Articles.Dtos;

public record ArticleDto
{
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string CoverName { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int Visit { get; set; }
    public string ShortContent { get; set; }
    public bool IsDeleted { get; set; }
}

