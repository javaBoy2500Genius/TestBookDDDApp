using MediatR;
using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Abstraction.Behaivor;

public sealed class UnitOfWorkBehaivor<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse>
where TRequest:IBaseCommand
{

    private readonly IUnitOfWork _unitOfWork;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var response = await next();

        if (response is Result { IsSuccess: true })
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return response;

    }
}