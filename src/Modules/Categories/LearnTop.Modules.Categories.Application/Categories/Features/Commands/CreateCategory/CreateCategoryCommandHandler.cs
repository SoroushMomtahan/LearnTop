using LearnTop.Modules.Categories.Application.Abstractions.Data;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Application.Categories.Features.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResponse>
{

    public async Task<Result<CreateCategoryResponse>> Handle(
        CreateCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Category> categoryResult = Category.Create(request.Name, request.Description);
        if (categoryResult.IsFailure)
        {
            return Result.Failure<CreateCategoryResponse>(categoryResult.Error);
        }
        await categoryRepository.AddAsync(categoryResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCategoryResponse(categoryResult.Value.Id);
    }
}
