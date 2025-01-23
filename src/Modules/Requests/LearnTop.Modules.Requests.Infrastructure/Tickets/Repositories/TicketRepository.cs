using System.Data.Common;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Modules.Requests.Infrastructure.WriteDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace LearnTop.Modules.Requests.Infrastructure.Tickets.Repositories;

internal sealed class TicketRepository(
    RequestsDbContext requestsDbContext)
    : ITicketRepository
{

    public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Ticket? ticket = await requestsDbContext.Tickets
            .AsTracking()
            .Include(x => x.ReplyTickets)
            .AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return ticket;
    }
    public async Task AddAsync(Ticket ticket)
    {
        await requestsDbContext.Tickets.AddAsync(ticket);
        await requestsDbContext.ReplyTickets.AddRangeAsync(ticket.ReplyTickets);
    }
    public async Task AddAsync(ReplyTicket replyTicket)
    {
        await requestsDbContext.ReplyTickets.AddAsync(replyTicket);
    }
    public void Delete(Ticket ticket)
    {
        requestsDbContext.Entry(ticket).State = EntityState.Deleted;
    }
}
