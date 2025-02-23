using LearnTop.Modules.Ordering.Domain.Products.Models;

namespace LearnTop.Modules.Ordering.Domain.Products.Repositories;

public interface IProductRepository
{
    Task<Product?> GetAsync(Guid id);
    Task AddProductAsync(Product product, CancellationToken cancellationToken = default);
}
