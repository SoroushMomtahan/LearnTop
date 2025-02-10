using LearnTop.Modules.Information.Domain.Addresses.Errors;
using LearnTop.Modules.Information.Domain.Addresses.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Addresses.Models;

public class Address : Aggregate
{
    public int I { get; private set; }
}
