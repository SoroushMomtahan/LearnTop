﻿using LearnTop.Modules.Information.Domain.CourseProposals.Models;

namespace LearnTop.Modules.Information.Domain.CourseProposals.Repositories;

public interface ICourseProposalRepository
{
    void Update(CourseProposal courseProposal);
    Task AddAsync(CourseProposal courseProposal, CancellationToken cancellationToken = default);
}
