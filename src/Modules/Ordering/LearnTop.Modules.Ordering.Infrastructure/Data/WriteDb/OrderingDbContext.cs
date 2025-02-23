using System.Reflection;
using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Infrastructure.Discounts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;

public class OrderingDbContext(DbContextOptions<OrderingDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Order> Orders => Set<Order>();
    internal DbSet<Product> Products => Set<Product>();
    internal DbSet<Coupon> Coupons => Set<Coupon>();
    internal DbSet<Discount> Discounts => Set<Discount>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Ordering);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
