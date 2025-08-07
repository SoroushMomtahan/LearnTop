using LearnTop.Modules.Files.Application.Abstractions;
using LearnTop.Modules.Files.Application.Services;
using LearnTop.Modules.Files.Domain.Files.Errors;
using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Application.Features.Command.DeleteFile;

internal sealed class DeleteFileCommandHandler(
    IFileRepository fileRepository,
    IFileService fileService,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteFileCommand>
{

    public async Task<Result> Handle(
        DeleteFileCommand request, CancellationToken cancellationToken)
    {
        File? file = await fileRepository.GetAsync(request.FileName, cancellationToken);
        if (file is null)
        {
            return Result.Failure(FileErrors.FileNotExist);
        }
        fileService.Delete(file.Name, file.Extension);
        fileRepository.Delete(file);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
