using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.ClearCart;

internal sealed class ClearCartCommandHandler(
    CartService cartService) : ICommandHandler<ClearCartCommand, ClearCartResponse>
{
    public async Task<Result<ClearCartResponse>> Handle(
        ClearCartCommand request, CancellationToken cancellationToken)
    {
        await cartService.ClearAsync(request.CustomerId);
        return new ClearCartResponse();
    }
}
