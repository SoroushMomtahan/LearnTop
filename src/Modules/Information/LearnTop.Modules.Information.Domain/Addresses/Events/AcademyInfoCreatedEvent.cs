using LearnTop.Modules.Information.Domain.Addresses.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Addresses.Events;

public class AcademyInfoCreatedEvent(AcademyInfo academyInfo) : DomainEvent
{
    public AcademyInfo AcademyInfo { get; } = academyInfo;
}
