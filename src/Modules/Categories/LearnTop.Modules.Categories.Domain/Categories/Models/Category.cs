using LearnTop.Modules.Categories.Domain.Categories.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Domain.Categories.Models;

public class Category : Aggregate
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private readonly List<CategoryRelation> _parentCategories = [];
    private readonly List<CategoryRelation> _childCategories = [];

    public IReadOnlyList<CategoryRelation> ParentCategories => [.. _parentCategories];
    public IReadOnlyList<CategoryRelation> ChildCategories => [.. _childCategories];

    private Category() { }

    public static Result<Category> Create(string name, string? description = "")
    {
        return new Category()
        {
            Name = name,
            Description = description
        };
    }
    public Result AddParentCategory(CategoryRelation relation)
    {
        bool alreadyExistInParent = _parentCategories
            .Exists(x=>
                x.ParentCategoryId == relation.ParentCategoryId);
        if (alreadyExistInParent)
        {
            return Result.Failure(CategoryErrors.AlreadyExistInParentCategory(relation.ParentCategoryId));
        }
        
        bool alreadyExistInChild = _childCategories.Exists(x=>
                x.ChildCategoryId == relation.ParentCategoryId);
        if (alreadyExistInChild)
        {
            return Result.Failure(CategoryErrors.AlreadyExistInChildCategory(relation.ParentCategoryId));
        }
        
        _parentCategories.Add(relation);
        return Result.Success();
    }
    public Result AddChildCategory(CategoryRelation relation)
    {
        bool alreadyExistInChild = _childCategories.Exists(x=>
                x.ChildCategoryId == relation.ChildCategoryId);
        if (alreadyExistInChild)
        {
            return Result.Failure(CategoryErrors.AlreadyExistInChildCategory(relation.ChildCategoryId));
        }
        
        bool alreadyExistInParent = _parentCategories.Exists(x=>
            x.ParentCategoryId == relation.ChildCategoryId);
        if (alreadyExistInParent)
        {
            return Result.Failure(CategoryErrors.AlreadyExistInParentCategory(relation.ChildCategoryId));
        }
        _childCategories.Add(relation);
        return Result.Success();
    }
}
