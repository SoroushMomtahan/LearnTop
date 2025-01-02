using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.ValueObjects;

public record Firstname : ValueObject<string>
{
    public Firstname(string Value) : base(Value)
    {
        switch (Value.Length)
        {
            case < 2:
                throw new DomainException(UserErrors.LessThan2Character);
            case > 50:
                throw new DomainException(UserErrors.MoreThan20Character);
        }
    }
    public static implicit operator Firstname(string value) => new(value);
}
