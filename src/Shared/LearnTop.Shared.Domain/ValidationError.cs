namespace LearnTop.Shared.Domain;

/// <summary>
/// استانداردی برای خطا های اعتبارسنجی
/// </summary>
public sealed record ValidationError : Error
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    public ValidationError(Error[] errors)
        : base(
            "General.Validation",
            "یک یا چند خطای اعتبارسنجی رخ داد",
            ErrorType.Validation)
    {
        Errors = errors;
    }

    /// <summary>
    /// 
    /// </summary>
    public Error[] Errors { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    public static ValidationError FromResults(IEnumerable<Result> results)
    {
        return new(results.Where(static r => r.IsFailure).Select(static r => r.Error).ToArray());
    }
}

