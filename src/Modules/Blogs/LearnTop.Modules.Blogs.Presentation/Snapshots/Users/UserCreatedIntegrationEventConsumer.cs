using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.CreateUserSnapshot;
using LearnTop.Modules.Identity.IntegrationEvent;
using LearnTop.Shared.Application.Exceptions;
using MassTransit;

namespace LearnTop.Modules.Blogs.Presentation.Snapshots.Users;

public class UserCreatedIntegrationEventConsumer(ISender sender) : IConsumer<UserCreatedIntegrationEvent>
{

    public async Task Consume(ConsumeContext<UserCreatedIntegrationEvent> context)
    {
        Result result = await sender.Send(new CreateUserSnapshotCommand(context.Message.UserId, context.Message.DisplayName ?? ""));
        if (result.IsFailure)
        {
            throw new LearnTopException(nameof(CreateUserSnapshotCommand), result.Error);
        }
    }
}
