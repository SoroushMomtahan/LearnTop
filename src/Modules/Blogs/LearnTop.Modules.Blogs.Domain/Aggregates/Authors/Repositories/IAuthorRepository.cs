using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Repositories;

public interface IAuthorRepository
{
    Task CreateAsync(Author author, CancellationToken cancellationToken = default);
    
}
