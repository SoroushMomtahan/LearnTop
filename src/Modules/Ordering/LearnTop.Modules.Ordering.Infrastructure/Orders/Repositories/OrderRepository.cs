using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Ordering.Infrastructure.Orders.Repositories;

internal sealed class OrderRepository(
    OrderingDbContext orderingDbContext) : IOrderRepository
{

    public Task<Order?> GetAsync(Guid orderId)
    {
        return orderingDbContext.Orders.FirstOrDefaultAsync(x=>x.Id == orderId);
    }
    public async Task AddAsync(Order order)
    {
        await orderingDbContext.Orders.AddAsync(order);
    }
    public Task RemoveAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
