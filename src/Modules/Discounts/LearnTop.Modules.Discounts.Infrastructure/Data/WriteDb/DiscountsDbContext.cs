using LearnTop.Modules.Discounts.Application.Abstractions.Data;
using LearnTop.Modules.Discounts.Domain.Discounts.Models;
using LearnTop.Modules.Discounts.Infrastructure.Discounts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Discounts.Infrastructure.Data.WriteDb;

public class DiscountsDbContext(DbContextOptions<DiscountsDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Discount> Discounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Discounts);
        modelBuilder.ApplyConfiguration(new CourseDiscountConfiguration());
        modelBuilder.ApplyConfiguration(new UserDiscountConfiguration());
    }
}
