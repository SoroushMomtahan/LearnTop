using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories;

public class TicketRepository(
    AcademyDbContext dbContext
    )
    : ITicketRepository
{
    public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Tickets.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
    public async Task AddAsync(Ticket ticket)
    {
        await dbContext.Tickets.AddAsync(ticket);
    }
    public async Task AddReplyTicketAsync(ReplyTicket replyTicket)
    {
        await dbContext.ReplyTickets.AddAsync(replyTicket);
    }

    public void Update(Ticket ticket)
    {
        dbContext.Tickets.Update(ticket);
    }
}
