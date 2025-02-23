using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Queries.GetProductById;

public record GetProductByIdQuery(Guid ProductId) 
    : IQuery<GeyProductByIdResponse>;
