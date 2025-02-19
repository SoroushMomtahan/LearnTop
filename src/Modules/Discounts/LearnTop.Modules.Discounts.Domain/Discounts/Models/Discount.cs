using LearnTop.Modules.Discounts.Domain.Discounts.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Discounts.Domain.Discounts.Models;

public class Discount : Aggregate
{
    public int Percent { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public bool ForAllUsers { get; private set; }
    private readonly List<CourseDiscount> _courseDiscounts = [];
    private readonly List<UserDiscount> _userDiscounts = [];
    public IReadOnlyList<CourseDiscount> CourseDiscounts => _courseDiscounts;
    public IReadOnlyList<UserDiscount> UserDiscounts => _userDiscounts;
    
    private Discount() { }

    public static Result<Discount> Create(
        int percent, 
        DateTime startAt, 
        DateTime endAt)
    {
        if (startAt > endAt)
        {
            return Result.Failure<Discount>(DiscountErrors.StartDateIsAfterEndDate);
        }
        if (percent is < 20 or > 70)
        {
            return Result.Failure<Discount>(DiscountErrors.PercentIsOutOfRange);
        }
        Discount discount = new()
        {
            Percent = percent,
            StartAt = startAt,
            EndAt = endAt
        };
        return discount;
    }
    public Result AddCourseDiscounts(IReadOnlyList<Guid> courseIds)
    {
        if (courseIds.Count == 0)
        {
            return Result.Failure(DiscountErrors.EmptyListOfCourse);
        }
        var distinctCourseIds = courseIds.Distinct().ToList();
        var newCourseDiscounts = distinctCourseIds
            .Where(courseId=>_courseDiscounts.TrueForAll(x => x.CourseId != courseId))
            .Select(courseId=>CourseDiscount.Create(Id, courseId)).ToList();
        
        _courseDiscounts.AddRange(newCourseDiscounts);
        return Result.Success();
    }
    
    public void AddUserDiscounts(IReadOnlyList<Guid> userIds)
    {
        if (userIds.Count == 0)
        {
            ForAllUsers = true;
        }
        var distinctUserIds = userIds.Distinct().ToList();
        var newUserIds = distinctUserIds
            .Where(userId => _userDiscounts.TrueForAll(x => x.UserId != userId))
            .Select(userId=>UserDiscount.Create(Id, userId)).ToList();
        
        _userDiscounts.AddRange(newUserIds);
    }
    public void SubtractCourseDiscounts(IReadOnlyList<Guid> courseIds)
    {
        var distinctCourseIds = courseIds.Distinct().ToList();
        _courseDiscounts.RemoveAll(x => distinctCourseIds.Any(courseId => courseId == x.CourseId));
    }
    public void SubtractUserDiscounts(IReadOnlyList<Guid> userIds)
    {
        var distinctUserIds = userIds.Distinct().ToList();
        _userDiscounts.RemoveAll(x => distinctUserIds.Any(userId => userId == x.UserId));
    }
}
