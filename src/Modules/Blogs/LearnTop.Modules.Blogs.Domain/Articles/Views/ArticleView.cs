using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Views;

public class ArticleView : EntityView
{
    public Guid AuthorId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Status { get; private set; }
    public bool IsDeleted { get; private set; }
    private readonly List<TagView> _tagViews = [];
    public IReadOnlyList<TagView> Tags => [.. _tagViews];
}
