using LearnTop.Modules.Discounts.Domain.Discounts.Models;

namespace LearnTop.Modules.Discounts.Domain.Discounts.Repositories;

public interface IDiscountRepository
{
    Task AddAsync(Discount discount, CancellationToken cancellationToken = default);
}
