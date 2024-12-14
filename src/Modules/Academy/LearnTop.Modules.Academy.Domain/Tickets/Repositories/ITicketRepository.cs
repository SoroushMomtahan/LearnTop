using LearnTop.Modules.Academy.Domain.Tickets.Models;

namespace LearnTop.Modules.Academy.Domain.Tickets.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Ticket ticket);
    Task AddReplyTicketAsync(ReplyTicket replyTicket);
    void Update(Ticket ticket);
}
