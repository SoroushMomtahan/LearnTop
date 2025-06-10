using System.Reflection;
using LearnTop.Modules.Files.Application.Abstractions;
using LearnTop.Modules.Files.Domain.Files.Models;
using LearnTop.Modules.Files.Infrastructure.Files.Db.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Infrastructure.Data;

public class FilesDbContext(DbContextOptions<FilesDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<File> Files => Set<File>();
    public DbSet<ImageFileSetting> ImageFileSettings => Set<ImageFileSetting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Files);
        modelBuilder.ApplyConfiguration(new ImageFileConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}
