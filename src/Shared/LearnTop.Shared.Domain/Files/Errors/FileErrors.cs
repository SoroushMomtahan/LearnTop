using File = LearnTop.Shared.Domain.Files.Models.File;

namespace LearnTop.Shared.Domain.Files.Errors;

public static class FileErrors
{
    public static Error NotValidExtension()
    {
        return new(
            "Files.NotValidExtension",
            $"تنها یکی از پسوند های{string.Join(", ", File.ValidFormats)} مجاز می باشد.",
            ErrorType.Validation
            );
    }
    public static readonly Error NotValidSize = new(
        "Files.NotValidSize",
        $"سایز فایل ارسالی نمی تواند بیشتر از {File.MaxFileSize} باشد.",
        ErrorType.Validation);

    public static readonly Error FileNotExist = new(
        "Files.FileNotExist",
        $"فایلی برای پاک کردن یافت نشد.",
        ErrorType.Validation);
}
