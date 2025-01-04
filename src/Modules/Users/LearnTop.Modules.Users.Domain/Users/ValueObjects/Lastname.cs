using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.ValueObjects;

public record Lastname : ValueObject<string>
{
    public Lastname(string Value) : base(Value)
    {
        
    }
    public static implicit operator Lastname(string value) => new(value);
}
