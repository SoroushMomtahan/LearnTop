using LearnTop.Modules.Information.Domain.Banners.Enums;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Banners.Models;

public class BannerSetting : Entity
{
    public List<string> ValidExtensions { get; private set; }
    public int MaxSize { get; private set; }
    
    public static readonly BannerSetting InitialSetting = new()
    {
        
        ValidExtensions = [.. Enum.GetNames<Extension>()],
        MaxSize = 5
    };

    public static BannerSetting Create(List<string> validExtensions, int maxSize)
    {
        return new()
        {
            ValidExtensions = validExtensions,
            MaxSize = maxSize
        };
    }
}
