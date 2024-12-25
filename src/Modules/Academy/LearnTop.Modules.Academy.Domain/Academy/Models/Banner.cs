using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Models;

public class Banner : Entity
{
    public Guid AcademyId { get; private set; }
    public string ImageUrl { get; private set; }
    public string Title { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }

    private Banner() { }

    public static Banner Create(string image, string title, DateTime startAt, DateTime endAt)
    {
        Banner banner = new()
        {
            ImageUrl = image,
            Title = title,
            StartAt = startAt,
            EndAt = endAt
        };
        return banner;
    }
}
