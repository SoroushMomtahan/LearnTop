using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.ViewModels;

public class BannerView : EntityView
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}
