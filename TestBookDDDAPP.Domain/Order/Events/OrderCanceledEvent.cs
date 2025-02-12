using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Order.Events;

public record OrderCanceledEvent(OrderId id): IDomainEvent;