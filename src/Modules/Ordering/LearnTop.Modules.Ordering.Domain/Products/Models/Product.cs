using LearnTop.Modules.Ordering.Domain.Products.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Products.Models;

public class Product : Aggregate
{
    public Guid ProductId { get; private set; }
    public long Price { get; private set; }
    private Product() {}
    public static Result<Product> Create(Guid productId, long price)
    {
        if (price is < 50000 or > 10000000)
        {
            return Result.Failure<Product>(ProductErrors.PriceOutOfRange);
        }
        return new Product()
        {
            ProductId = productId,
            Price = price
        };
    }
    public Result ChangePrice(long price)
    {
        if (price is < 500000 or > 10000000)
        {
            return Result.Failure(ProductErrors.PriceOutOfRange);
        }
        Price = price;
        return Result.Success();
    }
}
