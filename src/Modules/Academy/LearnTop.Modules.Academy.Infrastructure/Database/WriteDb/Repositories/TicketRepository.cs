using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories;

public class TicketRepository(
    AcademyDbContext dbContext
    )
    : ITicketRepository
{
    public async Task AddAsync(Ticket ticket)
    {
        await dbContext.Tickets.AddAsync(ticket);
    }

    public Task<Guid> UpdateAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> FindAll()
    {
        throw new NotImplementedException();
    }
}
