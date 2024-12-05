using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Database.ReadDb.Repositories;

public class TicketViewRepository(
    AcademyViewDbContext academyViewDbContext) : ITicketViewRepository
{
    public List<TicketView> FindAll(int pageIndex, int pageSize)
    {
        return
        [
            .. academyViewDbContext.TicketViews.AsNoTracking()
                .Skip(pageIndex)
                .Take(pageSize)
        ];
    }

    public async Task AddAsync(TicketView ticketView)
    {
        await academyViewDbContext.TicketViews.AddAsync(ticketView);
    }

    public Task UpdateAsync(TicketView ticketView)
    {
        academyViewDbContext.TicketViews.Update(ticketView);
        return Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return academyViewDbContext.SaveChangesAsync(cancellationToken);
    }
}
