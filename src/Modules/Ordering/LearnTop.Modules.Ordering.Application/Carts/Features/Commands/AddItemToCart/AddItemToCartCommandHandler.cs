using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.AddItemToCart;

internal sealed class AddItemToCartCommandHandler(CartService cartService) : ICommandHandler<AddItemToCartCommand, AddItemToCartResponse>
{

    public async Task<Result<AddItemToCartResponse>> Handle(
        AddItemToCartCommand request, 
        CancellationToken cancellationToken)
    {
        await cartService.AddItemAsync(request.CustomerId, request.CourseId);
        
        return new AddItemToCartResponse();
    }
}
