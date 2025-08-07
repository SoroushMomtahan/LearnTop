using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Modules.Files.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Infrastructure.Files.Db.Repositories;

internal sealed class FileRepository(FilesDbContext filesDbContext) : IFileRepository
{

    public async Task CreateAsync(File file, CancellationToken cancellationToken = default)
    {
        await filesDbContext.Files.AddAsync(file, cancellationToken);
    }
    public void Delete(File file)
    {
        filesDbContext.Files.Remove(file);
    }
    public async Task<File?> GetAsync(string fileName, CancellationToken cancellationToken = default)
    {
        return await filesDbContext.Files.FirstOrDefaultAsync((file)=>file.Name == fileName, cancellationToken);
    }
}
