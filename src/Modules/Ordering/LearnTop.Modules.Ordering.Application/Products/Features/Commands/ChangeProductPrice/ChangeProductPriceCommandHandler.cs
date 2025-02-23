using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Products.Errors;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Commands.ChangeProductPrice;

internal sealed class ChangeProductPriceCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeProductPriceCommand, ChangeProductPriceResponse>
{

    public async Task<Result<ChangeProductPriceResponse>> Handle(
        ChangeProductPriceCommand request, 
        CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetAsync(request.ProductId);
        if (product is null)
        {
            return Result.Failure<ChangeProductPriceResponse>(ProductErrors.NotFound);
        }
        
        Result result = product.ChangePrice(request.NewPrice);
        if (result.IsFailure)
        {
            return Result.Failure<ChangeProductPriceResponse>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new ChangeProductPriceResponse();
    }
}
