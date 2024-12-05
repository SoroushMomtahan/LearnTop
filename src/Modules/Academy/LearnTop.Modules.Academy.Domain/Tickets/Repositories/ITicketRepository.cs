using LearnTop.Modules.Academy.Domain.Tickets.Models;

namespace LearnTop.Modules.Academy.Domain.Tickets.Repositories;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<Guid> UpdateAsync(Ticket ticket);
}
