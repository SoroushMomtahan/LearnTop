using LearnTop.Modules.Academy.Domain.CourseProposals.Models;

namespace LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;

public interface ISkillRepository
{
    Task AddAsync(List<Skill> skills, CancellationToken cancellationToken = default);
}
