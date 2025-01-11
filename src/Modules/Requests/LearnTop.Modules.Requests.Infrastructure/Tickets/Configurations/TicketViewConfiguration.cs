using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Academy.Infrastructure.Database.ReadDb.Configurations;

public class TicketViewConfiguration : IEntityTypeConfiguration<TicketView>
{
    public void Configure(EntityTypeBuilder<TicketView> builder)
    {

    }
}
