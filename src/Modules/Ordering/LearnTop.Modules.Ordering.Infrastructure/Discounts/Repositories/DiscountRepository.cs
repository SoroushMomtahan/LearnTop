using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using LearnTop.Modules.Ordering.Domain.Discounts.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Ordering.Infrastructure.Discounts.Repositories;

internal sealed class DiscountRepository(OrderingDbContext orderingDbContext) : IDiscountRepository
{

    public async Task AddAsync(
        Discount discount, 
        CancellationToken cancellationToken = default)
    {
        await orderingDbContext.Discounts.AddAsync(discount, cancellationToken);
    }
    public async Task<List<Discount>> GetAsync(Guid productId, Guid customerId, CancellationToken cancellationToken = default)
    {
        return await orderingDbContext.Discounts
            .Include(x=>x.ProductDiscounts)
            .Include(x=>x.CustomerDiscounts)
            .Where(x=>x.CustomerDiscounts.Any(customer=>customer.CustomerId==customerId) && 
                      x.ProductDiscounts.Any(product=>product.ProductId == productId))
            .ToListAsync(cancellationToken);
    }
}
