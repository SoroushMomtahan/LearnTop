namespace LearnTop.Shared.Domain;
public abstract record ValueObject<TValue>(TValue Value)
    where TValue : class 
{
    public TValue Value { get; } = Value;
    public static implicit operator TValue(ValueObject<TValue> valueObject) => valueObject.Value;
}
