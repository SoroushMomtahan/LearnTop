using LearnTop.Modules.Academy.Domain.Academy.ViewModels;
using LearnTop.Modules.Academy.Domain.CourseProposals.ViewModels;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Database.ReadDb;

public class AcademyViewDbContext(DbContextOptions<AcademyViewDbContext> options) : DbContext(options)
{
    public DbSet<TicketView> TicketViews { get; set; }
    public DbSet<ReplyTicketView> ReplyTicketViews { get; set; }
    public DbSet<CourseProposalView> CourseProposalViews { get; set; }
    public DbSet<BannerView> BannerViews { get; set; }
    public DbSet<AcademyInfoView> AcademyInfoViews { get; set; }
    public DbSet<ContactUsView> ContactUsViews { get; set; }
}
