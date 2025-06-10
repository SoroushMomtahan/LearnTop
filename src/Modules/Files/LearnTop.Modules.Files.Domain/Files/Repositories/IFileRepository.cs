using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Domain.Files.Repositories;

public interface IFileRepository
{
    Task CreateAsync(File file, CancellationToken cancellationToken = default);
}
