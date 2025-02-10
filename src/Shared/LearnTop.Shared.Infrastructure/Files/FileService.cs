using LearnTop.Shared.Application.Services;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Domain.Files.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LearnTop.Shared.Infrastructure.Files;

public class FileService(IOptions<FileOptions> options) : IFileService
{

    public Result Validate(IFormFile file, string[] allowExtensions, int maxSizeByMb = 5)
    {
        if (file.Length > maxSizeByMb * 1024 * 1024)
        {
            return Result.Failure(Error.Problem(
                "Files.SizeIsOutOfRange", 
                $"حداکثر اندازه فایل ارسالی نمی تواند بیشتر از {maxSizeByMb} مگابایت باشد."));
        }
        string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowExtensions.Contains(extension))
        {
            return Result.Failure(Error.Problem(
                "Files.NotAllExtensions", 
                $"فایل ارسالی باید یکی از بین {string.Join(", ", allowExtensions)} باشد"));
        }
        return Result.Success();
    }
    public async Task<Result<byte[]>> SaveAsync(IFormFile file, string fileName, string folderName = "")
    {
        string fileExtension = Path.GetExtension(file.FileName);
        string pathName = Path.Combine($"{options.Value.RootPath}/{folderName}", fileName + fileExtension);
        await using var fileStream = new FileStream(pathName, FileMode.Create);
        await using var memoryStream = new MemoryStream();
        await file.CopyToAsync(fileStream);
        await file.CopyToAsync(memoryStream);
        byte[] fileBytes = memoryStream.ToArray();
        return Result.Success(fileBytes);
    }
    public Result Delete(string fileName, string fileExtension, string folderName = "")
    {
        string filePath = Path.Combine($"{options.Value.RootPath}/{folderName}", fileName + "." + fileExtension);
        if (!File.Exists(filePath))
        {
            return Result.Failure(FileErrors.FileNotExist);
        }
        File.Delete(filePath);
        return Result.Success();
    }
}
