using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Views;

public class TagView : EntityView
{
    public Guid TagId { get; private set; }
    public Guid ArticleId { get; private set; }
    public ArticleView ArticleView { get; set; }
}
