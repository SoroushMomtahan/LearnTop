using LearnTop.Modules.Files.Application.Services;
using LearnTop.Modules.Files.Domain.Files.Errors;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LearnTop.Modules.Files.Infrastructure.Files.Services;

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
        string extension = Path.GetExtension(file.FileName).Replace(".", "").ToLowerInvariant();
        if (!allowExtensions.Contains(extension))
        {
            return Result.Failure(Error.Problem(
                "Files.NotAllExtensions", 
                $"فایل ارسالی باید یکی از بین {string.Join(", ", allowExtensions)} باشد"));
        }
        return Result.Success();
    }
    public async Task<byte[]> SaveAsync(IFormFile file, string fileName, string folderName = "")
    {
        string fileExtension = Path.GetExtension(file.FileName);
        string pathName = Path.Combine($"{options.Value.RootPath}/{folderName}", fileName + fileExtension);
        if (!Directory.Exists($"{options.Value.RootPath}/{folderName}"))
        {
            Directory.CreateDirectory(pathName);
        }
        await using var fileStream = new FileStream(pathName, FileMode.Create);
        await using var memoryStream = new MemoryStream();
        await file.CopyToAsync(fileStream);
        await file.CopyToAsync(memoryStream);
        byte[] fileBytes = memoryStream.ToArray();
        return fileBytes;
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
