using LearnTop.Modules.Discounts.Domain.Discounts.Models;
using LearnTop.Modules.Discounts.Domain.Discounts.Repositories;
using LearnTop.Modules.Discounts.Infrastructure.Data.WriteDb;

namespace LearnTop.Modules.Discounts.Infrastructure.Discounts.Repositories;

internal sealed class DiscountRepository(DiscountsDbContext discountsDbContext) : IDiscountRepository
{

    public async Task AddAsync(
        Discount discount, 
        CancellationToken cancellationToken = default)
    {
        await discountsDbContext.Discounts.AddAsync(discount, cancellationToken);
    }
}
