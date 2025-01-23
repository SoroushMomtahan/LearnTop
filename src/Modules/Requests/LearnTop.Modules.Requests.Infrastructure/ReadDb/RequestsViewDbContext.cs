using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Modules.Requests.Infrastructure.Tickets.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Requests.Infrastructure.ReadDb;

public class RequestsViewDbContext(
    DbContextOptions<RequestsViewDbContext> options) : DbContext(options)
{
    internal DbSet<TicketView> TicketViews => Set<TicketView>();
    internal DbSet<ReplyTicketView> ReplyTicketViews => Set<ReplyTicketView>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Requests);
        modelBuilder.ApplyConfiguration(new TicketViewConfiguration());
    }
}
