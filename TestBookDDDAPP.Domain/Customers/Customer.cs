using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Domain.Customers;

public class Customer : Entity<CustomerId>
{
    public Customer()
    {
        
    }
    public Address Address { get; private set; }
    public Name Name { get; private set; }
    public string Email { get; private set; }
    public Customer(CustomerId Id, Name name, string email, Address address) : base(Id)
    {
        Name = name;
        Email = email;
        Address = address;
    }
}