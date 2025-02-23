using LearnTop.Modules.Ordering.Domain.Orders.Models;

namespace LearnTop.Modules.Ordering.Domain.Orders.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetAsync(Guid orderId);
    Task AddAsync(Order order);
    Task RemoveAsync(Order order);
}
