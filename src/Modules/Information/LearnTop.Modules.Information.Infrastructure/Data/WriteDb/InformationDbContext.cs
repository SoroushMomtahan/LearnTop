using LearnTop.Modules.Information.Application.Abstractions.Data;
using LearnTop.Modules.Information.Domain.Banners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LearnTop.Modules.Academy.Infrastructure.Data.WriteDb;

public class InformationDbContext
    (DbContextOptions<InformationDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Banner> Banners => Set<Banner>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Information");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}
