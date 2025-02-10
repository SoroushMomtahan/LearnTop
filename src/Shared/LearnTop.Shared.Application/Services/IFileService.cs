using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Http;

namespace LearnTop.Shared.Application.Services;

public interface IFileService
{
    public Result Validate(IFormFile file, string[] allowExtensions, int maxSizeByMb = 5);
    public Task<Result<byte[]>> SaveAsync(IFormFile file, string fileName, string folderName = "");
    public Result Delete(string fileName, string fileExtension, string folderName = "");
}
