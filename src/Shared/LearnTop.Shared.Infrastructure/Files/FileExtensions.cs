using LearnTop.Shared.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Shared.Infrastructure.Files;

internal static class FileExtensions
{
    public static void AddFileServices(this IServiceCollection services)
    {
        services.ConfigureOptions<FileOptionsSetup>();
        services.AddSingleton<IFileService, FileService>();
    }
}
