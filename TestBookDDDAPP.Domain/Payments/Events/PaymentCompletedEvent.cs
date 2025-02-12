using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Payments.Events;

public record PaymentCompletedEvent(PaymentId id) :IDomainEvent;