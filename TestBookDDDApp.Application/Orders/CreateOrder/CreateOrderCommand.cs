using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Customers;
using TestBookDDDAPP.Domain.Order;

namespace TestBookDDDApp.Orders.CreateOrder;

public record CreateOrderCommand(OrderId id, Customer custmer):ICommand<Order>;