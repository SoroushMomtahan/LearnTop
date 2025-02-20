using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.RemoveItemFromCart;

public record RemoveItemFromCartCommand(Guid CustomerId, Guid CourseId) 
    : ICommand<RemoveItemFromCartResponse>;
