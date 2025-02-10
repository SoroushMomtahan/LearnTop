using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Banners.Errors;

public static class BannerErrors
{
    public static Error TitleLessThan3Character()
    {
        return new(
            "Banners.TitleLessThanThreeCharacter",
            $"عنوان نمی تواند کمتر از 3 کارارکتر باشد.",
            ErrorType.Validation
            );
    }
    public static readonly Error DescriptionLessThan3Character = new(
        "Banners.DescriptionLessThan3Character",
        $"توضیحات نمی تواند کمتر از 3 کاراکتر باشد.",
        ErrorType.Validation);
    
    public static readonly Error StartTimeBiggerThanEndTime = new(
        "Banners.StartTimeBiggerThanEndTime",
        $"زمان شروع نمی تواند بیشتر یا برابر با زمان پایان باشد.",
        ErrorType.Validation);
    public static readonly Error SettingsNotFound = new(
        "Banners.SettingsNotFound",
        $"تنظیمات اولیه بنر یافت نشد",
        ErrorType.Validation);
    public static readonly Error NotFound = new(
        "Banners.NotFound",
        $"بنری با شناسه ارسالی یافت نشد.",
        ErrorType.Validation);
}
