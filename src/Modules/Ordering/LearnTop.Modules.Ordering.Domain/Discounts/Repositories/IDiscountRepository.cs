using LearnTop.Modules.Ordering.Domain.Discounts.Models;

namespace LearnTop.Modules.Ordering.Domain.Discounts.Repositories;

public interface IDiscountRepository
{
    Task AddAsync(Discount discount, CancellationToken cancellationToken = default);
    Task<List<Discount>> GetAsync(Guid productId, Guid customerId, CancellationToken cancellationToken = default);
}
