using LearnTop.Shared.Application.Cqrs;
using Microsoft.AspNetCore.Http;

namespace LearnTop.Modules.Files.Application.Features.Command.AddFile;

public record AddFileCommand(
    Guid OwnerId,
    IFormFile File,
    string[] ValidFormats,
    int MaxFileSizeByMb) : ICommand<AddFileCommand.Response>
{
    public record Response(string FileName);
}
