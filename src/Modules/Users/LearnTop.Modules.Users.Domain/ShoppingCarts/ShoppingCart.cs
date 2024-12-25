using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.ShoppingCarts;

public class ShoppingCart : Aggregate
{
    public Guid BuyerId { get; private set; }
    public Guid Discount { get; private set; }
    private readonly List<ShoppingCartItem> _shoppingCartItems = [];
    public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => [.. _shoppingCartItems];
    public string TotalPrice { get; private set; }
    public string TotalItems { get; private set; }
}
