using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Requests.Infrastructure.Tickets.Configurations;

internal sealed class TicketViewConfiguration : IEntityTypeConfiguration<TicketView>
{
    public void Configure(EntityTypeBuilder<TicketView> builder)
    {
        builder.HasMany(x => x.ReplyTicketViews)
            .WithOne()
            .HasForeignKey(x => x.TicketViewId);
    }
}
