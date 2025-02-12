﻿using MediatR;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Abstraction.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{

}