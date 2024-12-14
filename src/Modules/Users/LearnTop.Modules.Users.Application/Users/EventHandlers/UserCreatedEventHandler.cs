using LearnTop.Modules.Users.Domain.Users.Events;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Users.Application.Users.EventHandlers;

public class UserCreatedEventHandler
    (IUserViewRepository userViewRepository)
    : IDomainEventHandler<UserCreatedEvent>
{

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        UserView userView = new()
        {
            Firstname = notification.User.Firstname,
            Lastname = notification.User.Lastname,
            Email = notification.User.Email,
            Password = notification.User.Password
        };
        await userViewRepository.AddAsync(userView);
        await userViewRepository.SaveChangesAsync(cancellationToken);
    }
}
