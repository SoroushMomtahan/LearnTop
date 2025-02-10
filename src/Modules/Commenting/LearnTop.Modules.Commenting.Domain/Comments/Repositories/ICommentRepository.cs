using LearnTop.Modules.Commenting.Domain.Comments.Models;

namespace LearnTop.Modules.Commenting.Domain.Comments.Repositories;

public interface ICommentRepository
{
    Task<List<Comment>> GetAsync();
    Task<Comment> GetAsync(Guid id);
    Task<Comment> CreateAsync(Comment comment);
}
