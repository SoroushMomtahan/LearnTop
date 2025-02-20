namespace LearnTop.Modules.Ordering.Application.Carts;

public class Cart
{
    public Guid CustomerId { get; init; }
    public List<CartItem> Items { get; init; } = [];

    internal static Cart CreateDefault(Guid customerId) => new() {CustomerId = customerId};
}
