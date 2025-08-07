using LearnTop.Modules.Files.Domain.Files.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Files.Domain.Files.Models;

public class File : Aggregate
{
    public Guid OwnerId { get; private set; }
    public static int MaxFileSize { get; private set; }
    public static string[] ValidFormats { get; private set; }
    public string Name { get; private set; }
    public string Extension { get; private set; }
    public byte[]? Data { get; private set; }
    
    private File() { }

    public File(string extension, string[] validFormats, int maxFileSizeByMb, string preFileName, Guid ownerId)
    {
        ValidFormats = validFormats;
        MaxFileSize = maxFileSizeByMb;
        OwnerId = ownerId;
        
        if (!ValidFormats.Contains(extension))
        {
            throw new DomainValidationException(FileErrors.NotValidExtension);
        }
        Extension = extension;
        Name = CreateFileName(preFileName);
    }
    private static string CreateFileName(string preFileName)
    {
        return string.IsNullOrEmpty(preFileName) ? 
            $"{DateTime.Now.Ticks}" : 
            $"{preFileName}-{DateTime.Now.Ticks}";
    } 
    public Result AddData(byte[] data)
    {
        if (data.Length > MaxFileSize * 1024 * 1024)
        {
            return Result.Failure(FileErrors.NotValidSize);
        }
        Data = data;
        return Result.Success();
    }
}
