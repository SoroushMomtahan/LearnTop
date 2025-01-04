using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.ValueObjects;

public record Firstname(string Value) : ValueObject<string>(Value)
{
    public static implicit operator Firstname(string value) => new(value);
}
