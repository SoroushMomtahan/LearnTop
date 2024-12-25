using LearnTop.Modules.Academy.Domain.CourseProposals.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.CourseProposals.Events;

public class CourseProposalCreatedEvent(CourseProposal courseProposal) : DomainEvent
{
    public CourseProposal CourseProposal { get; } = courseProposal;
}
