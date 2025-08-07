using LearnTop.Modules.Blogs.Application.Authors.Features.Commands.CreateAuthorByUserId;
using LearnTop.Modules.Identity.IntegrationEvent;
using LearnTop.Shared.Application.Exceptions;
using MassTransit;

namespace LearnTop.Modules.Blogs.Presentation.Authors.EventConsumers.CreateAuthorByUser;

public class UserCreatedIntegrationEventConsumer(
    ISender sender) : IConsumer<UserCreatedIntegrationEvent>
{

    public async Task Consume(
        ConsumeContext<UserCreatedIntegrationEvent> context)
    {
        Result result = await sender.Send(
            new CreateAuthorByUserIdCommand(context.Message.UserId, context.Message.Username, context.Message.DisplayName));
        if (result.IsFailure)
        {
            throw new LearnTopException(nameof(CreateAuthorByUserIdCommand), result.Error);
        }
    }
}
