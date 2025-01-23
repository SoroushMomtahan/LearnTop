using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Tagging.Data.WriteDb;

namespace Tagging.Tags.Features.CreateTag;

internal sealed class CreateTagCommandHandler(TaggingDbContext dbContext)
    : ICommandHandler<CreateTagCommand, CreateTagResponse>
{

    public async Task<Result<CreateTagResponse>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        Result<Models.Tag> result = Models.Tag.Create(request.Title, request.Description);
        if (result.IsFailure)
        {
            return Result.Failure<CreateTagResponse>(result.Error);
        }
        
        dbContext.Tags.Add(result.Value);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new CreateTagResponse(result.Value.Id);
    }
}
