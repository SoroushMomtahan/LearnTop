using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;

namespace LearnTop.Modules.Blogs.Infrastructure.Authors.Repositories;

internal sealed class AuthorRepository(BlogsDbContext blogsDbContext) : IAuthorRepository
{

    public async Task CreateAsync(
        Author author, 
        CancellationToken cancellationToken = default)
    {
        await blogsDbContext.Authors.AddAsync(author, cancellationToken);
    }
}
