using LearnTop.Modules.Files.Application.Abstractions;
using LearnTop.Modules.Files.Application.Services;
using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using File = LearnTop.Modules.Files.Domain.Files.Models.File;

namespace LearnTop.Modules.Files.Application.Features.Command.AddFile;

internal sealed class AddFileCommandHandler(
    IFileService fileService,
    IUnitOfWork unitOfWork,
    IFileRepository fileRepository) : ICommandHandler<AddFileCommand, AddFileCommand.Response>
{

    public async Task<Result<AddFileCommand.Response>> Handle(
        AddFileCommand request, 
        CancellationToken cancellationToken)
    {
        Result validationResult = fileService.Validate(request.File, request.ValidFormats, request.MaxFileSizeByMb);
        if (validationResult.IsFailure)
        {
            return Result.Failure<AddFileCommand.Response>(validationResult.Error);
        }
        string extension = Path.GetExtension(request.File.FileName).TrimStart('.');
        File file = new(
            extension,
            request.ValidFormats, 
            request.MaxFileSizeByMb,
            string.Empty);

        await fileService.SaveAsync(request.File, file.Name);
        
        await fileRepository.CreateAsync(file, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AddFileCommand.Response($"{file.Name}.{file.Extension}");
    }
}
