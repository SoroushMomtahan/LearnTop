using System.Diagnostics.CodeAnalysis;

namespace LearnTop.Shared.Domain;

/// <summary>
/// استانداردی برای نتیجه های برنامه
/// </summary>
public class Result
{
    /// <summary>
    /// وضعیت موفقیت یک نتیجه را مشخص می کند
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// وضعیت شکست یک نتیجه را مشخص می کند
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// خطای یک نتیجه شکست خورده را مشخص می کند
    /// </summary>
    public Error Error { get; }
    /// <summary>
    /// متد سازنده ای که با استفاده از آن می توان یک نتیجه تولید کرد
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="error"></param>
    /// <exception cref="ArgumentException"></exception>
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("خطای تولید شده نامعتبر است", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// متدی برای ایجاد یک نتیجه موفقیت آمیز
    /// </summary>
    /// <returns></returns>
    public static Result Success()
    {
        return new(true, Error.None);
    }

    /// <summary>
    /// متدی برای ایجاد یک نتیجه شکست خورده
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static Result Failure(Error error)
    {
        return new(false, error);
    }

    /// <summary>
    /// متدی برای ایجاد یک نتیجه موفقیت آمیز بهمراه مقدار
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new(value, true, Error.None);
    }

    /// <summary>
    /// متدی برای ایجاد یک نتیجه شکست خورده در سناریویی که نتیجه بازگشتی
    /// در صورت موفقیت دارای مقدار است
    /// </summary>
    /// <param name="error"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return new(default, false, error);
    }

    /// <summary>
    /// متدی برای ایجاد نتیجه شکست
    /// در سناریویی که شکست ، ناشی از اعتبارسنجی ناموفق بوده است
    /// </summary>
    /// <param name="error"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Result<TValue> ValidationFailure<TValue>(Error error)
    {
        return new(default, false, error);
    }
}

/// <summary>
/// کلاسی برای استاندارد سازی نتایج همراه با مقدار
/// </summary>
/// <typeparam name="TValue">نوع مقدار</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;
    /// <summary>
    /// ویژگی ای که مقدار نتیجه را بر می گرداند
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("دسترسی به مقدار نتیجه شکست خورده امکان پذیر نیست");

    /// <summary>
    /// متد سازنده ای برای ایجاد نتایج همراه با مقدار
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isSuccess"></param>
    /// <param name="error"></param>
    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }


    /// <summary>
    /// تبدیل ضمنی مقدار به نتیجه
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}
