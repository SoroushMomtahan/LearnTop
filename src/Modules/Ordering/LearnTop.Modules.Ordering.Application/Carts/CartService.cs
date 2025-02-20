using LearnTop.Shared.Application.Caching;

namespace LearnTop.Modules.Ordering.Application.Carts;

public class CartService(ICacheService cacheService)
{
    public async Task AddItemAsync(Guid customerId, Guid courseId)
    {
        string cartName = CreateCacheKey(customerId);
        Cart cart = await GetAsync(customerId);
        CartItem cartItem = cart.Items.Find(x => x.CourseId == courseId);
        if (cartItem is not null)
        {
            return;
        }
        cart.Items.Add(new() { CourseId = courseId });
        await cacheService.SetAsync(cartName, cart);
    }
    public async Task RemoveItemAsync(Guid customerId, Guid courseId)
    {
        string cartName = CreateCacheKey(customerId);
        Cart cart = await GetAsync(customerId);
        CartItem cartItem = cart.Items.Find(x => x.CourseId == courseId);
        if (cartItem is null)
        {
            return;
        }
        cart.Items.Remove(cartItem);
        await cacheService.SetAsync(cartName, cart);
    }
    public async Task ClearAsync(Guid customerId)
    {
        string cartName = CreateCacheKey(customerId);
        var cart = Cart.CreateDefault(customerId);
        await cacheService.SetAsync(cartName, cart);
    }
    private async Task<Cart> GetAsync(Guid customerId)
    {
        string cartName = CreateCacheKey(customerId);
        return await cacheService.GetAsync<Cart>(cartName) ?? Cart.CreateDefault(customerId);
    }
    private static string CreateCacheKey(Guid customerId)
    {
        return $"Cart-{customerId}";
    }
}
