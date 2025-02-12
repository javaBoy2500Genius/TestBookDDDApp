using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Customers;
using TestBookDDDAPP.Domain.Order;

namespace TestBookDDDApp.Orders.CreateOrder;

public sealed class CreateOrderCommandHandler :ICommandHandler<CreateOrderCommand,Order>
{
    private readonly IRepository<Order> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateOrderCommandHandler(IRepository<Order> repository, IUnitOfWork unitOfWork, IRepository<Customer> repositoryCustomer)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var order = Order.CreateOrder(request.id, request.custmer);
            await _repository.AddAsync(order, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Create(order);
        }
        catch (Exception ex)
        {
            return Result.Failure<Order>(new Error("400", ex.Message));
        }

    }
}