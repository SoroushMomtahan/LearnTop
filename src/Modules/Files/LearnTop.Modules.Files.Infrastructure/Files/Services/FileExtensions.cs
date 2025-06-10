using LearnTop.Modules.Files.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Files.Infrastructure.Files.Services;

internal static class FileExtensions
{
    public static void AddFileServices(this IServiceCollection services)
    {
        services.ConfigureOptions<FileOptionsSetup>();
        services.AddSingleton<IFileService, FileService>();
    }
}
