using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Order;

namespace TestBookDDDApp.Orders.CanceledOrder;

public record CancelOrderCommand(OrderId id) :ICommand<Order>;