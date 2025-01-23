using LearnTop.Modules.Requests.Domain.Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Requests.Infrastructure.Tickets.Configurations;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Priority).HasConversion<string>();
        builder.Property(t => t.Status).HasConversion<string>();
        builder.Property(t => t.Section).HasConversion<string>();

        builder.HasMany(t => t.ReplyTickets)
            .WithOne()
            .HasForeignKey(t => t.TicketId);
    }
}
