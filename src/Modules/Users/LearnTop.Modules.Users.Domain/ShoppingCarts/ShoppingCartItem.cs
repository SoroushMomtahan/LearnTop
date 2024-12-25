using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.ShoppingCarts;

public class ShoppingCartItem : Entity
{
    public Guid ProductId { get; private set; }
    public string Price { get; private set; }
    public string Discount { get; private set; }
}
