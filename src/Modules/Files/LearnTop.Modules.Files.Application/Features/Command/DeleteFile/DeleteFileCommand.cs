using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Files.Application.Features.Command.DeleteFile;

public record DeleteFileCommand(string FileName) : ICommand;
