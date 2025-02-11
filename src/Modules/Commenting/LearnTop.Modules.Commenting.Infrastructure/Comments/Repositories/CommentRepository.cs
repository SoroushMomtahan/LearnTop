using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Modules.Commenting.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Commenting.Infrastructure.Comments.Repositories;

public class CommentRepository(CommentingDbContext commentingDbContext) : ICommentRepository
{

    public Task<List<Comment>> GetAsync(CancellationToken cancellationToken = default)
    {
        return commentingDbContext.Comments
            .Include(c=>c.Replies)
            .ToListAsync(cancellationToken);
    }
    public Task<Comment?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return commentingDbContext.Comments
            .Include(c=>c.Replies)
            .FirstOrDefaultAsync(c=>c.Id==id,cancellationToken);
    }
    public async Task CreateAsync(Comment comment, CancellationToken cancellationToken = default)
    {
        await commentingDbContext.Comments.AddAsync(comment, cancellationToken);
    }
    public void Delete(Comment comment)
    {
        commentingDbContext.Comments.Remove(comment);
    }
}
