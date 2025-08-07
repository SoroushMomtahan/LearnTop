namespace LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    private Category(){}

    public static Category Create(Guid id, string name)
    {
        return new()
        {
            Id = id,
            Name = name
        };
    }
}
