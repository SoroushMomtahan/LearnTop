using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Domain.Categories.Errors;

public static class CategoryErrors
{
    public static Error AlreadyExistInChildCategory(Guid categoryId) => new(
        "Categories.AlreadyExistInChildCategory",
        $"دسته بندی با شناسه {categoryId} قبلا به عنوان زیر گروه انتخاب شده است.",
        ErrorType.Conflict);
    
    public static Error AlreadyExistInParentCategory(Guid categoryId) => new(
        "Categories.AlreadyExistInChildCategory",
        $"دسته بندی با شناسه {categoryId} قبلا به عنوان سرگروه انتخاب شده است.",
        ErrorType.Conflict);

    public static readonly Error NotFound = new(
        "Categories.NotFound",
        "دسته بندی مورد نظر یافت نشد.",
        ErrorType.NotFound);
}
