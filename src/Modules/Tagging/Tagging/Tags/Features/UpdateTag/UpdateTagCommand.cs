using LearnTop.Shared.Application.Cqrs;

namespace Tagging.Tags.Features.UpdateTag;

public record UpdateTagCommand(
    Guid TagId,
    string Title, 
    string Description) : ICommand<UpdateTagResponse>;
