using LearnTop.Modules.Academy.Domain.CourseProposals.Models;
using LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories.CourseProposals;

public class SkillRepository(AcademyDbContext dbContext) : ISkillRepository
{

    public async Task AddAsync(List<Skill> skills, CancellationToken cancellationToken = default)
    {
        await dbContext.AddRangeAsync(skills, cancellationToken);
    }
}
