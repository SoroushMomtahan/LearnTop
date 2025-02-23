using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand, CreateProductResponse>
{

    public async Task<Result<CreateProductResponse>> Handle(
        CreateProductCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Product> result = Product.Create(request.ProductId, request.Price);
        
        if (result.IsFailure)
        {
            return Result.Failure<CreateProductResponse>(result.Error);
        }
        
        await productRepository.AddProductAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateProductResponse();
    }
}
