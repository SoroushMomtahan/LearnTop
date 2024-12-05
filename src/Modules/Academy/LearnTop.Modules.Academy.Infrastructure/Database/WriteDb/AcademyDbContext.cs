using System.Reflection;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Shared.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb;

public class AcademyDbContext
    (DbContextOptions<AcademyDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Academy");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
