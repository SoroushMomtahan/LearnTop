namespace LearnTop.Modules.Blogs.Application.Views.ArticleViews;

public class ArticleView
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public List<Guid> TagIds { get; set; }
    public AuthorView AuthorView { get; set; }
    public string CoverName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ShortContent { get; set; }
    public string Status { get; set; }
    public bool IsDeleted { get; set; }
    public int Visit { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
