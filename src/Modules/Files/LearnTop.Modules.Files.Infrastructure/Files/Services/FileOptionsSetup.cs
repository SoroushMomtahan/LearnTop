using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LearnTop.Modules.Files.Infrastructure.Files.Services;

internal sealed class FileOptionsSetup(IConfiguration configuration) : IConfigureOptions<FileOptions>
{

    public void Configure(FileOptions options)
    {
        configuration.GetSection(nameof(FileOptions)).Bind(options);
    }
}
