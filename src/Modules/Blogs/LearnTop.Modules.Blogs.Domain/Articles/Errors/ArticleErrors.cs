﻿using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Errors;

public static class ArticleErrors
{
    public static Error Empty(string name)
    {
        return new(
            "Articles.NotEmpty",
            $"فیلد {name} نمی تواند خلی باشد.",
            ErrorType.Validation
            );
    }
    public static Error NotFound(Guid blogId)
    {
        return new(
            "Articles.NotFound",
            $"مقاله ای با شناسه {blogId} یافت نشد.",
            ErrorType.NotFound
            );
    }
    public static Error TitleIsLessThan3Characters()
    {
        return new(
            "Articles.TitleIsLessThan3Characters",
            "عنوان نمی تواند کمتر از 3 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error TitleIsGreaterThan100Characters()
    {
        return new(
            "Articles.TitleIsGreaterThan100Characters",
            "عنوان نمی تواند بیشتر از 100 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error ContentIsLessThan3Characters()
    {
        return new(
            "Articles.ContentIsLessThan3Characters",
            "محتوا نمی تواند کمتر از 3 کاراکتر باشد.",
            ErrorType.Validation);
    }
    public static Error TagNotFound(Guid tagId)
    {
        return new("Articles.TagNotFound", $"تگی با شناسه {tagId} یافت نشد.", ErrorType.NotFound);
    }
    public static Error StatusIsNotInRange()
    {
        return new(
            "Articles.StatusIsNotInRange",
            "وضعیت وارد شده نادرست است.",
            ErrorType.Validation
            );
    }
}