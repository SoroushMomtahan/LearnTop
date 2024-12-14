using System.Reflection;
using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb;

public class AcademyDbContext
    (DbContextOptions<AcademyDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Ticket> Tickets => Set<Ticket>();
    internal DbSet<ReplyTicket> ReplyTickets => Set<ReplyTicket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Academy");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
