using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Modules.Files.Infrastructure.Data;
using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Infrastructure.Files.Db.Repositories;

internal sealed class FileRepository(FilesDbContext filesDbContext) : IFileRepository
{

    public async Task CreateAsync(File file, CancellationToken cancellationToken = default)
    {
        await filesDbContext.Files.AddAsync(file, cancellationToken);
    }
}
