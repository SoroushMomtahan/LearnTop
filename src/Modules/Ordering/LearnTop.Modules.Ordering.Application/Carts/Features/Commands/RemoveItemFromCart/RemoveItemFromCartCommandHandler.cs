using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.RemoveItemFromCart;

internal sealed class RemoveItemFromCartCommandHandler(
    CartService cartService)
    : ICommandHandler<RemoveItemFromCartCommand, RemoveItemFromCartResponse>
{

    public async Task<Result<RemoveItemFromCartResponse>> Handle(
        RemoveItemFromCartCommand request, 
        CancellationToken cancellationToken)
    {
        await cartService.RemoveItemAsync(request.CustomerId, request.CourseId);
        return new RemoveItemFromCartResponse();
    }
}
