using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;

namespace LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;

public interface ITicketViewRepository
{
    List<TicketView> Get(int pageIndex, int pageSize, bool includeDeletedRows = false);
    List<TicketView> Get(Guid ticketId, int pageIndex, int pageSize, bool includeDeletedRows = false);
    List<TicketView> GetBySearch(string searchString, int pageIndex, int pageSize, bool includeDeletedRows = false);
    List<TicketView> GetByStatus(TicketStatus status, int pageIndex, int pageSize, bool includeDeletedRows = false);
    List<TicketView> GetByStatus(TicketPriority priority, int pageIndex, int pageSize, bool includeDeletedRows = false);
    List<TicketView> GetByStatus(TicketSection section, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task AddAsync(TicketView ticketView);
    void Delete(Guid ticketId);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
