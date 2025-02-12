using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Domain.Order;

public record OrderItem
{
    public OrderItem()
    {
        
    }
    internal OrderItem( Book.Book book, int count)
    {
        if (count < 0)
            throw new ArgumentException("count must be positive");

        Book=book;
        Count=count;
    }
    public Book.Book Book { get; private set; }
    public int  Count { get; private set; }

    public Money TotalPrice => new (Book.Price.Currency, Book.Price.Amount *Count);

}