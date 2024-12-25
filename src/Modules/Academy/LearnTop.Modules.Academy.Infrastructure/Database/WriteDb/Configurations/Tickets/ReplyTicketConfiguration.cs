using LearnTop.Modules.Academy.Domain.Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Configurations.Tickets;

public class ReplyTicketConfiguration : IEntityTypeConfiguration<ReplyTicket>
{

    public void Configure(EntityTypeBuilder<ReplyTicket> builder)
    {
        builder.Property(static p => p.Version).IsRowVersion();
    }
}
