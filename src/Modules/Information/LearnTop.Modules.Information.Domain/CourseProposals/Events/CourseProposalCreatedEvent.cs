using LearnTop.Modules.Information.Domain.CourseProposals.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.CourseProposals.Events;

public class CourseProposalCreatedEvent(CourseProposal courseProposal) : DomainEvent
{
    public CourseProposal CourseProposal { get; } = courseProposal;
}
