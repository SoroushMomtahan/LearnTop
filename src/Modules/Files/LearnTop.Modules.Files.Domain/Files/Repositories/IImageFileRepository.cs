using LearnTop.Modules.Files.Domain.Files.Models;

namespace LearnTop.Modules.Files.Domain.Files.Repositories;

public interface IImageFileRepository
{
    Task<ImageFileSetting> GetFirstAsync();
}
