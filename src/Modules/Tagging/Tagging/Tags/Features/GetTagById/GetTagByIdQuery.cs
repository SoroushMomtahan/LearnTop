using LearnTop.Shared.Application.Cqrs;

namespace Tagging.Tags.Features.GetTagById;

public sealed record GetTagByIdQuery(Guid TagId) : IQuery<GetTagByIdResponse>;
