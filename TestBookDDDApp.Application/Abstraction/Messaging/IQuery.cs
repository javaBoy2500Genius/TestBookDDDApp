using MediatR;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> 
{
    
}