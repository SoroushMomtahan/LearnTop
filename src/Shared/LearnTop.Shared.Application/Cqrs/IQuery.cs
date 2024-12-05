using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Shared.Application.Cqrs;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
