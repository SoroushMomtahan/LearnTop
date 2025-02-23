using LearnTop.Modules.Ordering.Application.Products.Dtos;
using LearnTop.Modules.Ordering.Domain.Products.Errors;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler(
    IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, GeyProductByIdResponse>
{

    public async Task<Result<GeyProductByIdResponse>> Handle(
        GetProductByIdQuery request, 
        CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetAsync(request.ProductId);
        if (product is null)
        {
            return Result.Failure<GeyProductByIdResponse>(ProductErrors.NotFound);
        }
        
        ProductDto productDto = new()
        {
            ProductId = product.ProductId,
            Price = product.Price
        };
        
        return new GeyProductByIdResponse(productDto);
    }
}
