using System.Linq.Expressions;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Order;

namespace TestBookDDDApp.Orders.Predicate;

public sealed class GetOrderIdPredicate(OrderId id) :AggregationRoot<Order>
{
    protected override Expression<Func<Order, bool>> Predicate => order=>order.Id==id;
}