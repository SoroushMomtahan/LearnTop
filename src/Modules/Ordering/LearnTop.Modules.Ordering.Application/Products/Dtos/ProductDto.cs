namespace LearnTop.Modules.Ordering.Application.Products.Dtos;

public record ProductDto
{
    public Guid ProductId { get; set; }
    public long Price { get; set; }
}
