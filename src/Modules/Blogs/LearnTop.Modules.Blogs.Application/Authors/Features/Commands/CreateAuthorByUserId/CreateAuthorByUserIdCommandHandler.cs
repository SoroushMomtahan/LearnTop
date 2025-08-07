using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Authors.Features.Commands.CreateAuthorByUserId;

internal sealed class CreateAuthorByUserIdCommandHandler(
    IAuthorRepository authorRepository, 
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAuthorByUserIdCommand>
{

    public async Task<Result> Handle(
        CreateAuthorByUserIdCommand request,
        CancellationToken cancellationToken)
    {
        var author = Author.Create(
            request.UserId,
            request.Username,
            request.DisplayName);
        
        await authorRepository.CreateAsync(author, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
