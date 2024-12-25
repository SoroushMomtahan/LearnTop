using LearnTop.Modules.Academy.Domain.Academy.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Events;

public class AcademyInfoCreatedEvent(AcademyInfo academyInfo) : DomainEvent
{
    public AcademyInfo AcademyInfo { get; } = academyInfo;
}
