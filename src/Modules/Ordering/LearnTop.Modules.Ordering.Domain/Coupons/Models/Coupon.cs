using LearnTop.Modules.Ordering.Domain.Coupons.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Models;

public class Coupon : Aggregate
{
    public string Code { get; private set; }
    public long Ceil { get; private set; }
    public long Floor { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime ExpireAt { get; private set; }

    private readonly List<CouponyCategory> _categories = [];
    private readonly List<CouponyProduct> _products = [];
    private readonly List<CouponyUser> _users = [];

    public IReadOnlyList<CouponyCategory> Categories => [.. _categories];
    public IReadOnlyList<CouponyProduct> Products => [.. _products];
    public IReadOnlyList<CouponyUser> Users => [.. _users];

    private Coupon() {}

    public static Result<Coupon> Create(string code, long ceil, long floor, DateTime expireAt)
    {
        if (expireAt < DateTime.Now)
        {
            return Result.Failure<Coupon>(CouponErrors.InValidExpireTime);
        }
        if (ceil <= floor)
        {
            return Result.Failure<Coupon>(CouponErrors.InValidCeil);
        }
        if (ceil < 500000 || floor < 500000)
        {
            return Result.Failure<Coupon>(CouponErrors.InValidCeilOrFloor);
        }
        return new Coupon()
        {
            Code = code,
            Ceil = ceil,
            Floor = floor,
            ExpireAt = expireAt
        };
    }
    public Result Update(string code, long ceil, long floor, DateTime expireAt)
    {
        ChangeCode(code);
        
        Result changeCeilResult = ChangeCeil(ceil);
        if (changeCeilResult.IsFailure)
        {
            return Result.Failure(changeCeilResult.Error);
        }
        
        Result changeFloorResult = ChangeFloor(floor);
        if (changeFloorResult.IsFailure)
        {
            return Result.Failure(changeFloorResult.Error);
        }
        
        Result changeExpireAtResult = ChangeExpireAt(expireAt);
        if (changeExpireAtResult.IsFailure)
        {
            return Result.Failure(changeExpireAtResult.Error);
        }
        return Result.Success();
    }
    public void ChangeCode(string code)
    {
        Code = code;
    }
    public Result ChangeCeil(long ceil)
    {
        if (ceil <= Floor)
        {
            return Result.Failure(CouponErrors.InValidCeil);
        }
        if (ceil < 500000)
        {
            return Result.Failure<Coupon>(CouponErrors.InValidCeilOrFloor);
        }
        Ceil = ceil;
        return Result.Success();
    }
    public Result ChangeFloor(long floor)
    {
        if (Ceil <= floor)
        {
            return Result.Failure(CouponErrors.InValidCeil);
        }
        if (floor < 500000)
        {
            return Result.Failure(CouponErrors.InValidCeilOrFloor);
        }
        Floor = floor;
        return Result.Success();
    }
    public Result ChangeExpireAt(DateTime expireAt)
    {
        if (expireAt < DateTime.Now)
        {
            return Result.Failure(CouponErrors.InValidExpireTime);
        }
        ExpireAt = expireAt;
        return Result.Success();
    }
    public Result AddCategory(Guid categoryId)
    {
        CouponyCategory? foundCategory = _categories.Find(x => x.CategoryId == categoryId);
        if (foundCategory is not null)
        {
            return Result.Success();
        }
        var category = CouponyCategory.Create(categoryId, Id);
        _categories.Add(category);
        return Result.Success();
    }
    public Result AddProduct(Guid productId)
    {
        CouponyProduct? foundProduct = _products.Find(x => 
            x.ProductId == productId && x.CouponId == Id);
        if (foundProduct is not null)
        {
            return Result.Success();
        }
        var product = CouponyProduct.Create(productId, Id);
        _products.Add(product);
        return Result.Success();
    }
    public Result AddUser(Guid userId)
    {
        CouponyUser? foundUser = _users.Find(x => x.UserId == userId && x.CouponId == Id);
        if (foundUser is not null)
        {
            return Result.Success();
        }
        var user = CouponyUser.Create(userId, Id);
        _users.Add(user);
        return Result.Success();
    }
    public Result RemoveCategory(Guid categoryId)
    {
        CouponyCategory? foundCategory = _categories.Find(x => 
            x.CategoryId == categoryId && x.CouponId == Id);
        if (foundCategory is not null)
        {
            _categories.Remove(foundCategory);
        }
        return Result.Success();
    }
    public Result RemoveProduct(Guid productId)
    {
        CouponyProduct? foundProduct = _products.Find(x => x.ProductId == productId && x.CouponId == Id);
        if (foundProduct is not null)
        {
            _products.Remove(foundProduct);
        }
        return Result.Success();
    }
    public Result RemoveUser(Guid userId)
    {
        CouponyUser? foundUser = _users.Find(x => x.UserId == userId && x.CouponId == Id);
        if (foundUser is not null)
        {
            _users.Remove(foundUser);
        }
        return Result.Success();
    }
    public void ChangeDeleteStatus(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}
