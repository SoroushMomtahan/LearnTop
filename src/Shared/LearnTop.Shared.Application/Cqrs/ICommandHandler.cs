﻿using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Shared.Application.Cqrs;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{

}

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;
