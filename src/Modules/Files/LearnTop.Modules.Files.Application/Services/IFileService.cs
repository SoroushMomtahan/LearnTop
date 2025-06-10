using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Http;

namespace LearnTop.Modules.Files.Application.Services;

public interface IFileService
{
    Result Validate(IFormFile file, string[] allowExtensions, int maxSizeByMb = 5);
    Task<byte[]> SaveAsync(IFormFile file, string fileName, string folderName = "");
    Result Delete(string fileName, string fileExtension, string folderName = "");
}
