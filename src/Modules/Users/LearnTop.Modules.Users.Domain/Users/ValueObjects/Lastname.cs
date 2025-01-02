using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.ValueObjects;

public record Lastname : ValueObject<string>
{
    public Lastname(string Value) : base(Value)
    {
        switch (Value.Length)
        {
            case < 2 :
                throw new DomainException(UserErrors.LessThan2Character);
            case > 50 :
                throw new DomainException(UserErrors.MoreThan50Character);
        }
    }
    public static implicit operator Lastname(string value) => new(value);
}
