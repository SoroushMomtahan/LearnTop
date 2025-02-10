using LearnTop.Modules.Information.Domain.Banners.Errors;
using LearnTop.Modules.Information.Domain.Banners.Events;
using LearnTop.Shared.Domain;
using File = LearnTop.Shared.Domain.Files.Models.File;

namespace LearnTop.Modules.Information.Domain.Banners.Models;

public class Banner : File
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }

    private Banner() {}

    public Banner(string extension, string[] validFormats, int maxFileSizeByMb, string preFileName = "")
        : base(extension, validFormats, maxFileSizeByMb, preFileName)
    {
        AddDomainEvent(new BannerCreatedEvent(Id));
    }
    public Result AddTitle(string title)
    {
        if (title.Length < 3)
        {
            return Result.Failure(BannerErrors.TitleLessThan3Character());
        }
        Title = title;
        return Result.Success();
    }
    public Result AddDescription(string description)
    {
        if (description.Length < 3)
        {
            return Result.Failure(BannerErrors.DescriptionLessThan3Character);
        }
        Description = description;
        return Result.Success();
    }
    public Result SetBannerLifetime(DateTime startAt, DateTime endAt)
    {
        if (startAt.CompareTo(endAt) != -1)
        {
            return Result.Failure(BannerErrors.StartTimeBiggerThanEndTime);
        }
        StartAt = startAt;
        EndAt = endAt;
        return Result.Success();
    }
}
