using LearnTop.Modules.Files.Domain.Files.Enums;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Files.Domain.Files.Models;

public class ImageFileSetting : Entity
{
    public int MaxSizeByMb { get; private set; }
    public string[] ValidFormat { get; private set; }

    private ImageFileSetting() { }

    public static readonly ImageFileSetting InitialSettings = new()
    {
        ValidFormat = [.. Enum.GetNames<ImageFormat>()],
        MaxSizeByMb = 5,
    };
    
    public static ImageFileSetting Create(int maxSizeByMb, string[] validFormat)
    {
        return new()
        {
            MaxSizeByMb = maxSizeByMb,
            ValidFormat = validFormat
        };
    }
}
