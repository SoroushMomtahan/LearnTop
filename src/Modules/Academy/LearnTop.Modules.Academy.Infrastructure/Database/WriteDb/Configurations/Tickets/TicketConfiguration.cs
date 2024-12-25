using LearnTop.Modules.Academy.Domain.Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Configurations.Tickets;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(static t => t.Priority).HasConversion<string>();
        builder.Property(static t => t.Status).HasConversion<string>();
        builder.Property(static t => t.Section).HasConversion<string>();

        builder.HasMany(static t => t.ReplyTickets)
            .WithOne()
            .HasForeignKey(static t => t.TicketId);

        builder.Property(static t => t.Version)
            .IsRowVersion();
    }
}
