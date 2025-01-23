using LearnTop.Shared.Application.Cqrs;

namespace Tagging.Tags.Features.CreateTag;

internal sealed record CreateTagCommand(
    string Title,
    string Description)
    : ICommand<CreateTagResponse>;
