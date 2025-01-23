using LearnTop.Shared.Domain;

namespace Tagging.Tags.Errors;

internal static class TagErrors
{
    public static readonly Error DescriptionLessThan3Character = 
        new(
            "Tags.DescriptionLessThan3Character",
            "توضیحات نمی تواند کمتر از 3 کاراکتر باشد.",
            ErrorType.Validation);
    
    public static readonly Error TitleIsEmpty = 
        new(
            "Tags.TitleLessThan2Character",
            "تگ می بایست حداقل یک کاراکتر داشته باشد.",
            ErrorType.Validation);
    public static readonly Error TagNotFound = 
        new(
            "Tags.TagNotFound",
            "تگی با شناسه ارسالی یافت نشد.",
            ErrorType.NotFound);
}
