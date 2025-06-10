using LearnTop.Modules.Information.Domain.Banners.Errors;
using LearnTop.Modules.Information.Domain.Banners.Events;
using LearnTop.Shared.Domain;
namespace LearnTop.Modules.Information.Domain.Banners.Models;

public class Banner : Aggregate
{
    public Guid ImageFileId { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }

    private Banner() {}

    public static Result<Banner> Create(string? title, string? description, DateTime startAt, DateTime endAt)
    {
        if (title is not null && title.Length < 3)
        {
            return Result.Failure<Banner>(BannerErrors.TitleLessThan3Character());
        }
        if (description is not null && description.Length < 3)
        {
            return Result.Failure<Banner>(BannerErrors.DescriptionLessThan3Character);
        }
        if (startAt.CompareTo(endAt) != -1)
        {
            return Result.Failure<Banner>(BannerErrors.StartTimeBiggerThanEndTime);
        }
        Banner banner = new()
        {
            Title = title,
            Description = description,
            StartAt = startAt,
            EndAt = endAt
        };
        banner.AddDomainEvent(new BannerCreatedEvent(banner.Id));
        return banner;
    }
}
