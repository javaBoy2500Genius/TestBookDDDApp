using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Order;

public class OrderId(Guid value) : BaseId(value);