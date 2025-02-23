using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Products.Errors;

public static class ProductErrors
{
    public static readonly Error PriceOutOfRange = new(
        "Products.PriceOutOfRange",
        "قیمت نمی تواند کمتر از 500 هزار ریال و بیشتر از 10 میلیون ریال باشد.",
        ErrorType.Problem);

    public static readonly Error ProductTypeMismatch = new(
        "Products.ProductTypeMismatch",
        "نمی توان قیمت محصولات پولی را تغییر داد",
        ErrorType.Problem);
    public static readonly Error TypeOutOfBound = new(
        "Products.TypeOutOfBound",
        "نوع محصول صحیح نیست",
        ErrorType.Problem);
    public static readonly Error NotFound = new(
        "Products.NotFound",
        "محصولی با شناسه مورد نظر یافت نشد.",
        ErrorType.NotFound);
}
