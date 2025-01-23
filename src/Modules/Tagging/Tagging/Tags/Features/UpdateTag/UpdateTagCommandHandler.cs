using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.WriteDb;
using Tagging.Tags.Errors;
using Tagging.Tags.Models;

namespace Tagging.Tags.Features.UpdateTag;

internal sealed class UpdateTagCommandHandler(TaggingDbContext taggingDbContext) : ICommandHandler<UpdateTagCommand, UpdateTagResponse>
{

    public async Task<Result<UpdateTagResponse>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        Tag? tag = await taggingDbContext.Tags.FirstOrDefaultAsync(x=>x.Id == request.TagId, cancellationToken);
        if (tag is null)
        {
            return Result.Failure<UpdateTagResponse>(TagErrors.TagNotFound);
        }
        tag.Update(request.Title, request.Description);
        await taggingDbContext.SaveChangesAsync(cancellationToken);
        return new UpdateTagResponse(tag.Id);
    }
}
