using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Views;

public class ArticleView : EntityView
{
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public bool IsDeleted { get; set; }
    public List<ArticleTagView> TagViews { get; set; }
}
