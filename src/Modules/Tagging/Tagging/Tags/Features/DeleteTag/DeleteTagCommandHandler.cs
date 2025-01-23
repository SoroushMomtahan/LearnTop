using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.ReadDb;
using Tagging.Data.WriteDb;
using Tagging.Tags.Errors;
using Tagging.Tags.Models;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.DeleteTag;

internal sealed class DeleteTagCommandHandler(
    TaggingDbContext taggingDbContext,
    TaggingViewDbContext taggingViewDbContext)
    : ICommandHandler<DeleteTagCommand, DeleteTagResponse>
{

    public async Task<Result<DeleteTagResponse>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        Tag? tag = await taggingDbContext.Tags.FirstOrDefaultAsync(x => x.Id == request.TagId, cancellationToken);
        if (tag is null)
        {
            return Result.Failure<DeleteTagResponse>(TagErrors.TagNotFound);
        }

        if (request.IsSoftDelete)
        {
            tag.SoftDelete();
        }
        else
        {
            taggingDbContext.Tags.Remove(tag);
            await DeleteTagFromView(request, cancellationToken);
        }
        await taggingDbContext.SaveChangesAsync(cancellationToken);
        return new DeleteTagResponse(tag.Id);
    }
    private async Task DeleteTagFromView(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        TagView? tagView = await taggingViewDbContext.TagViews.FirstOrDefaultAsync(x=>x.Id ==request.TagId, cancellationToken);
        if (tagView is null)
        {
            throw new LearnTopException(nameof(DeleteTagFromView));
        }
        taggingViewDbContext.TagViews.Remove(tagView);
        await taggingViewDbContext.SaveChangesAsync(cancellationToken);
    }
}
