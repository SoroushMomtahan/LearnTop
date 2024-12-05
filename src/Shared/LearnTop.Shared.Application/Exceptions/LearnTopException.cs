using LearnTop.Shared.Domain;

namespace LearnTop.Shared.Application.Exceptions;

/// <summary>
/// قالبی برای exception های دامنه
/// </summary>
/// <param name="requestName"></param>
/// <param name="error"></param>
/// <param name="innerException"></param>
public sealed class LearnTopException(string requestName, Error? error = default, Exception? innerException = default)
    : Exception("خطای دامنه", innerException)
{
    /// <summary>
    /// 
    /// </summary>
    public string RequestName { get; } = requestName;

    /// <summary>
    /// 
    /// </summary>
    public Error? Error { get; } = error;
}
