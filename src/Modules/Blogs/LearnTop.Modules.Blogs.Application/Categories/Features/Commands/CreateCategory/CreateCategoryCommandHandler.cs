using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Application.Categories.Events;
using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;
using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Modules.Blogs.Application.Categories.Features.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryLookupRepository categoryLookupRepository,
    IUnitOfWork unitOfWork,
    IPublisher publisher)
    : ICommandHandler<CreateCategoryCommand>
{

    public async Task<Result> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = Category.Create(request.CategoryId, request.Name);
        
        await categoryLookupRepository.CreateAsync(category);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publisher.Publish(new CategoryCreatedEvent(category), cancellationToken);
        
        return Result.Success();
    }
}
