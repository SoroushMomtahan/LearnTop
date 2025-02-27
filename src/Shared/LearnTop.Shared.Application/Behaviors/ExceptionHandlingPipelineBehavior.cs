﻿using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LearnTop.Shared.Application.Behaviors;

internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception) when (exception is DomainValidationException domainException)
        {
            throw domainException;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);

            throw new LearnTopException(typeof(TRequest).Name, innerException: exception);
        }
    }
}
