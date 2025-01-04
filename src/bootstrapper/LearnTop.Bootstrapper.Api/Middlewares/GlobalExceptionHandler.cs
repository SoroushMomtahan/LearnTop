using FluentValidation;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Bootstrapper.Api.Middlewares;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Title = "Server failure"
        };
        switch (exception)
        {
            case ValidationException validationException:
                problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
                break;
            case DomainValidationException domainException:
                problemDetails.Extensions.Add("DomainException", 
                    new
                    {
                        Type = domainException.Error.Type.ToString(), 
                        Message = domainException.Error.Description
                    });
                break;
        }
        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
