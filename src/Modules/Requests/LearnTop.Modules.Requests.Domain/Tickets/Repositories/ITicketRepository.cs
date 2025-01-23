using LearnTop.Modules.Requests.Domain.Tickets.Models;

namespace LearnTop.Modules.Requests.Domain.Tickets.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Ticket ticket);
    void Delete(Ticket ticket);
    Task AddAsync(ReplyTicket replyTicket);
}
