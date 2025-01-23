using LearnTop.Modules.Requests.Domain.Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Requests.Infrastructure.Tickets.Configurations;

internal sealed class ReplyTicketConfiguration : IEntityTypeConfiguration<ReplyTicket>
{

    public void Configure(EntityTypeBuilder<ReplyTicket> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
