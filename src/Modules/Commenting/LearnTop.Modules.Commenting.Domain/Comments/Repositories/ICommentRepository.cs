using LearnTop.Modules.Commenting.Domain.Comments.Models;

namespace LearnTop.Modules.Commenting.Domain.Comments.Repositories;

public interface ICommentRepository
{
    Task<List<Comment>> GetAsync(CancellationToken cancellationToken = default);
    Task<Comment?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Comment comment, CancellationToken cancellationToken = default);
    void Delete(Comment comment);
}
