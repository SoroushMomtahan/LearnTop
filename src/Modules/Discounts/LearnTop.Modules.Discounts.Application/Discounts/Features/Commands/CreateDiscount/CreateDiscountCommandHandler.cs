using LearnTop.Modules.Discounts.Application.Abstractions.Data;
using LearnTop.Modules.Discounts.Domain.Discounts.Models;
using LearnTop.Modules.Discounts.Domain.Discounts.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Discounts.Application.Discounts.Features.Commands.CreateDiscount;

internal sealed class CreateDiscountCommandHandler(
    IDiscountRepository discountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateDiscountCommand, CreateDiscountResponse>
{

    public async Task<Result<CreateDiscountResponse>> Handle(
        CreateDiscountCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Discount> createDiscountResult = Discount.Create(
            request.Percent, request.StartAt, request.EndAt);

        if (createDiscountResult.IsFailure)
        {
            return Result.Failure<CreateDiscountResponse>(createDiscountResult.Error);
        }
        
        Discount discount = createDiscountResult.Value;
        
        Result addCourseDiscountResult = discount.AddCourseDiscounts(request.CourseIds);
        if (addCourseDiscountResult.IsFailure)
        {
            return Result.Failure<CreateDiscountResponse>(addCourseDiscountResult.Error);
        }
        discount.AddUserDiscounts(request.UserIds);
        
        await discountRepository.AddAsync(discount, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateDiscountResponse(discount.Id);
    }
}
