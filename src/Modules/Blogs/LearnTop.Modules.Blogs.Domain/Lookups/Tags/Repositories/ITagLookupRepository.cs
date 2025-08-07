using LearnTop.Modules.Blogs.Domain.Lookups.Tags.Models;

namespace LearnTop.Modules.Blogs.Domain.Lookups.Tags.Repositories;

public interface ITagLookupRepository
{
    Task<Tag?> GetTagByIdAsync(Guid id);
}
