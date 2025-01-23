using LearnTop.Shared.Domain;

namespace Tagging.Tags.Views;

public class TagView : EntityView
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
}
