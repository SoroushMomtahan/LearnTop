using LearnTop.Modules.Academy.Domain.Academy.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Events;

public class ContactUsCreatedEvent(ContactUs contactUs) : DomainEvent
{
    public ContactUs ContactUs { get; } = contactUs;
}
