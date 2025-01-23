using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Infrastructure.Tickets.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Requests.Infrastructure.WriteDb;

public class RequestsDbContext(DbContextOptions<RequestsDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Ticket> Tickets => Set<Ticket>();
    internal DbSet<ReplyTicket> ReplyTickets => Set<ReplyTicket>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Requests);
        modelBuilder
            .ApplyConfiguration(new TicketConfiguration())
            .ApplyConfiguration(new ReplyTicketConfiguration());
    }
}
