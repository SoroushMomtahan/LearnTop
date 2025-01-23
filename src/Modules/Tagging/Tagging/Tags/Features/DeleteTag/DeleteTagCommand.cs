using LearnTop.Shared.Application.Cqrs;

namespace Tagging.Tags.Features.DeleteTag;

public record DeleteTagCommand(Guid TagId, bool IsSoftDelete) : ICommand<DeleteTagResponse>;
