using LearnTop.Modules.Academy.Domain.CourseProposals.Models;

namespace LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;

public interface ICourseProposalRepository
{
    void Update(CourseProposal courseProposal);
    Task AddAsync(CourseProposal courseProposal, CancellationToken cancellationToken = default);
    Task AddSkillsAsync(List<Skill> skills, CancellationToken cancellationToken = default);
}
