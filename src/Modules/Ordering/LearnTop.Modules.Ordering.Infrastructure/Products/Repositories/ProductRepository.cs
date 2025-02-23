using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;


namespace LearnTop.Modules.Ordering.Infrastructure.Products.Repositories;

public class ProductRepository(
    OrderingDbContext orderingDbContext) : IProductRepository
{

    public async Task<Product?> GetAsync(Guid id)
    {
        return await orderingDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
    }
    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await orderingDbContext.Products.AddAsync(product, cancellationToken);
    }
}
