using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Customers;
using TestBookDDDAPP.Domain.Order.Enum;
using TestBookDDDAPP.Domain.Payments;
using TestBookDDDAPP.Domain.Payments.Enum;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Domain.Order;

public class Order : Entity<OrderId>
{
    public Order()
    {
        
    }
    public Order(OrderId id, Customer customer) : base(id)
    {
        Customer = customer;
        Status = OrderStatus.Pending;
    }

    public Customer Customer { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    public Money TotalPrice =>
        new (Items.FirstOrDefault()?.TotalPrice.Currency ?? Currency.None , Items.Sum(it => it.TotalPrice.Amount));


    public OrderStatus Status { get; private set; }

    public Payment Payment { get; private set; }
    public PaymentId PaymentId { get; private set; }

    private readonly List<OrderItem> _items = [];


    public void AddItem(Book.Book book, int count)
    {
        var item = new OrderItem(book, count);
        _items.Add(item);
    }


    public void CanceledOrder()
    {
        Status= OrderStatus.Canceled;
    }

    public void CompletePayment(Payment payment)
    {
        if (payment.Status != PaymentStatus.Completed)
            throw new InvalidOperationException("payment not completed");


        Payment=payment;
        Status = OrderStatus.Completed;
    }



}