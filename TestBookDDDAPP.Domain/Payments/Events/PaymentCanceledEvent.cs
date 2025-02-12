using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Payments.Events;

public record PaymentCanceledEvent(PaymentId id): IDomainEvent;