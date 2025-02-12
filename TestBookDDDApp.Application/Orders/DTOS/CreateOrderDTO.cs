using TestBookDDDAPP.Domain.Customers;
using TestBookDDDAPP.Domain.Order;

namespace TestBookDDDApp.Application.Orders.Новая_папка;

public record CreateOrderDTO(OrderId id, Customer customer);