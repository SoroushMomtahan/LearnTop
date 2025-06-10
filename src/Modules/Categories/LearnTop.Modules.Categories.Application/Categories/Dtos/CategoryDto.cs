namespace LearnTop.Modules.Categories.Application.Categories.Dtos;

public record CategoryDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? LightImage { get; set; }
    public string? DarkImage { get; set; }
    public string? Icon { get; set; }
    public List<Guid> ParentCategories { get; set; }
    public List<Guid> ChildCategories { get; set; }
}

