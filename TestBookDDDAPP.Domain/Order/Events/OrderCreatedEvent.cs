using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Order.Events;

public record OrderCreatedEvent(OrderId id) : IDomainEvent;