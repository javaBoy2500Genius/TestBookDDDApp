using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Payments;

public class PaymentId(Guid value) : BaseId(value);