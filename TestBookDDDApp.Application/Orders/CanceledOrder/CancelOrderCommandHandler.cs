using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Order;
using TestBookDDDApp.Orders.Predicate;

namespace TestBookDDDApp.Orders.CanceledOrder;

public sealed class CancelOrderCommandHandler :ICommandHandler<CancelOrderCommand,Order>
{
    private readonly IRepository<Order> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CancelOrderCommandHandler(IRepository<Order> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Order>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var orderExist = await _repository.GetAsync(new GetOrderIdPredicate(request.id), cancellationToken);

            if (orderExist == null)
                return Result.Failure<Order>(new Error("404", "Order not found"));

            orderExist.CanceledOrder();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Create(orderExist);
        }
        catch (Exception ex)
        {
            return Result.Failure<Order>(new Error("400", ex.Message));
        }
    }
}