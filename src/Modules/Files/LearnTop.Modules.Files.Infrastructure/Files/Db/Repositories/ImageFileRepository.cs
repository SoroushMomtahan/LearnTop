using LearnTop.Modules.Files.Domain.Files.Models;
using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Modules.Files.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Files.Infrastructure.Files.Db.Repositories;

public class ImageFileRepository(FilesDbContext filesDbContext) : IImageFileRepository
{

    public async Task<ImageFileSetting> GetFirstAsync()
    {
        return await filesDbContext.ImageFileSettings.FirstOrDefaultAsync();
    }
}
