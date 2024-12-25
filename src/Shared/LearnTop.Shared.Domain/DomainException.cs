namespace LearnTop.Shared.Domain;

public class DomainException(Error error) : Exception
{
    public Error Error { get; } = error;

}
