using LearnTop.Modules.Information.Domain.CourseProposals.Models;

namespace LearnTop.Modules.Information.Domain.CourseProposals.Repositories;

public interface ISkillRepository
{
    Task AddAsync(List<Skill> skills, CancellationToken cancellationToken = default);
}
