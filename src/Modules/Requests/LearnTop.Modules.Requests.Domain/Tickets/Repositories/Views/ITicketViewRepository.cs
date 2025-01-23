using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;

namespace LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;

public interface ITicketViewRepository
{
    Task<List<TicketView>> GetAsync(int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<TicketView> GetAsync(Guid ticketId);
    Task<List<TicketView>> GetBySearchAsync(string searchString, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<TicketView>> GetByStatusAsync(TicketStatus status, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<TicketView>> GetByPriorityAsync(TicketPriority priority, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<TicketView>> GetBySectionAsync(TicketSection section, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<long> GetTotalCountAsync();
    Task AddAsync(TicketView ticketView);
    Task AddAsync(ReplyTicketView replyTicketView);
    void Update(TicketView ticketView);
    void Delete(TicketView ticketView);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
