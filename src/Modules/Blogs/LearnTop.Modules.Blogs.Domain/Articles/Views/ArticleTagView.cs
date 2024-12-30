using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Views;

public class ArticleTagView : EntityView
{
    public Guid TagId { get; set; }
    public Guid ArticleId { get; set; }
}
