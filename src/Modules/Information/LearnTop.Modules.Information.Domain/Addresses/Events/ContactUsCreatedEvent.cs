using LearnTop.Modules.Information.Domain.Addresses.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Addresses.Events;

public class ContactUsCreatedEvent(ContactUs contactUs) : DomainEvent
{
    public ContactUs ContactUs { get; } = contactUs;
}
