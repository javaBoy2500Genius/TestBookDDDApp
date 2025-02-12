using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Payments.Enum;
using TestBookDDDAPP.Domain.Payments.Events;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Domain.Payments;

public class Payment : Entity<PaymentId>
{
    public Payment()
    {
        
    }
    public Payment(PaymentId Id, Money amount) : base(Id)
    {
        Amount = amount;
        Status = PaymentStatus.Pending;
    }
    public Money Amount { get; init; }
    public PaymentStatus Status { get; private set; }


    public void CanceledPayment()
    {
        RaiseDomainEvent(new PaymentCanceledEvent(Id));
        Status = PaymentStatus.Failed;
    }
    public void Completed()
    {
        RaiseDomainEvent(new PaymentCompletedEvent(Id));
        Status = PaymentStatus.Completed;
    }
}