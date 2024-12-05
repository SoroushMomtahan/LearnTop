namespace LearnTop.Shared.Domain;

/// <summary>
/// استانداری برای خطا های برنامه
/// </summary>
public record Error
{

    /// <summary>
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ErrorType"/>
    public ErrorType Type { get; }


    /// <summary>
    /// خطای آماده
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    /// <summary>
    /// خطای آماده برای مقادیر نال
    /// </summary>
    public static readonly Error NullValue = new(
        "General.Null",
        "مقدار تهی شناسایی شد.",
        ErrorType.Failure);

    /// <summary>
    /// متد سازنده برای ایجاد قالب استاندارد خطا
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <param name="type"></param>
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Error Failure(string code, string description)
    {
        return new(code, description, ErrorType.Failure);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Error NotFound(string code, string description)
    {
        return new(code, description, ErrorType.NotFound);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Error Problem(string code, string description)
    {
        return new(code, description, ErrorType.Problem);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Error Conflict(string code, string description)
    {
        return new(code, description, ErrorType.Conflict);
    }

    public static Error Validation(string code, string description)
    {
        return new(code, description, ErrorType.Validation);
    }
}
