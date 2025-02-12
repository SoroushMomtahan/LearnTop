using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Domain.Categories.Models;

public class CategoryRelation : Entity
{
    public Guid ParentCategoryId { get; private set; }
    public Guid ChildCategoryId { get; private set; }

    public Category ParentCategory { get; private set; }
    public Category ChildCategory { get; private set; }
    
    private CategoryRelation() { }

    public static Result<CategoryRelation> Create(Guid parentCategoryId, Guid childCategoryId)
    {
        return new CategoryRelation()
        {
            ParentCategoryId = parentCategoryId,
            ChildCategoryId = childCategoryId
        };
    }
}
