using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Modules.Requests.Infrastructure.ReadDb;
using LearnTop.Modules.Requests.Infrastructure.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Requests.Infrastructure.Tickets.Repositories;

internal sealed class TicketViewRepository(
    RequestsViewDbContext requestsViewDbContext)
    : ITicketViewRepository
{

    public async Task<List<TicketView>> GetAsync(int pageIndex, int pageSize, bool includeDeletedRows = false)
    {
        return await requestsViewDbContext.TicketViews
            .AsNoTracking()
            .Include(x => x.ReplyTicketViews)
            .AsNoTracking()
            .Skip(pageIndex)
            .Take(pageSize)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .ToListAsync();
    }
    public async Task<TicketView> GetAsync(Guid ticketId)
    {
        return await requestsViewDbContext.TicketViews.FindAsync(ticketId);
    }
    public async Task<List<TicketView>> GetBySearchAsync(string searchString, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await requestsViewDbContext.TicketViews
            .AsNoTracking()
            .Include(x => x.ReplyTicketViews)
            .AsNoTracking()
            .Skip(pageIndex)
            .Take(pageSize)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .Where(x=>x.Title.Contains(searchString) || x.Content.Contains(searchString))
            .ToListAsync();
    }
    public async Task<List<TicketView>> GetByStatusAsync(TicketStatus status, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await requestsViewDbContext.TicketViews
            .AsNoTracking()
            .Include(x => x.ReplyTicketViews)
            .AsNoTracking()
            .Skip(pageIndex)
            .Take(pageSize)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .Where(x=>x.Status.Equals(status))
            .ToListAsync();
    }
    public async Task<List<TicketView>> GetByPriorityAsync(TicketPriority priority, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await requestsViewDbContext.TicketViews
            .AsNoTracking()
            .Include(x => x.ReplyTicketViews)
            .AsNoTracking()
            .Skip(pageIndex)
            .Take(pageSize)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .Where(x=>x.Status.Equals(priority))
            .ToListAsync();
    }
    public async Task<List<TicketView>> GetBySectionAsync(TicketSection section, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await requestsViewDbContext.TicketViews
            .AsNoTracking()
            .Include(x => x.ReplyTicketViews)
            .AsNoTracking()
            .Skip(pageIndex)
            .Take(pageSize)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .Where(x=>x.Status.Equals(section))
            .ToListAsync();
    }
    public Task<long> GetTotalCountAsync()
    {
        return requestsViewDbContext.TicketViews.LongCountAsync();
    }
    public async Task AddAsync(TicketView ticketView)
    {
        await requestsViewDbContext.TicketViews.AddAsync(ticketView);
    }
    public async Task AddAsync(ReplyTicketView replyTicketView)
    {
        await requestsViewDbContext.ReplyTicketViews.AddAsync(replyTicketView);
    }
    public void Update(TicketView ticketView)
    {
        requestsViewDbContext.Entry(ticketView).State = EntityState.Modified;
    }
    public void Delete(TicketView ticketView)
    {
        requestsViewDbContext.TicketViews.Remove(ticketView);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await requestsViewDbContext.SaveChangesAsync(cancellationToken);
    }
}
