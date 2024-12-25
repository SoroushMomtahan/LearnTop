using LearnTop.Modules.Academy.Domain.CourseProposals.Models;
using LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories.CourseProposals;

public class CourseProposalRepository(AcademyDbContext dbContext) : ICourseProposalRepository
{

    public void Update(CourseProposal courseProposal)
    {
        dbContext.CourseProposals.Update(courseProposal);
    }
    public async Task AddAsync(CourseProposal courseProposal, CancellationToken cancellationToken = default)
    {
        await dbContext.CourseProposals.AddAsync(courseProposal, cancellationToken);
    }
}
