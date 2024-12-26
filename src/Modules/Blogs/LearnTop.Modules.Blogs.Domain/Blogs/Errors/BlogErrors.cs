using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Errors;

public static class BlogErrors
{
    public static Error Empty(string name)
    {
        return new(
            "Blogs.NotEmpty",
            $"فیلد {name} نمی تواند خلی باشد.",
            ErrorType.Validation
            );
    }
    public static Error NotFound(Guid blogId)
    {
        return new(
            "Blogs.NotFound",
            $"مقاله ای با شناسه {blogId} یافت نشد.",
            ErrorType.NotFound
            );
    }
    public static Error TitleIsLessThan3Characters()
    {
        return new(
            "Blogs.TitleIsLessThan3Characters",
            "عنوان نمی تواند کمتر از 3 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error TitleIsGreaterThan100Characters()
    {
        return new(
            "Blogs.TitleIsGreaterThan100Characters",
            "عنوان نمی تواند بیشتر از 100 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error ContentIsLessThan3Characters()
    {
        return new(
            "Blogs.ContentIsLessThan3Characters",
            "محتوا نمی تواند کمتر از 3 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error TagNotFound(Guid tagId)
    {
        return new("Blogs.TagNotFound", $"تگی با شناسه {tagId} یافت نشد.", ErrorType.NotFound);
    }
    public static Error CoomentNotFound(Guid commentId)
    {
        return new("Blogs.TagNotFound", $"نظری با شناسه {commentId} یافت نشد.", ErrorType.NotFound);
    }
    public static Error StatusIsNotInRange()
    {
        return new(
            "Blogs.StatusIsNotInRange",
            "وضعیت وارد شده نادرست است.",
            ErrorType.Validation
            );
    }
}
