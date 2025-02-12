using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Domain.Book;

public class BookId(Guid Id) :BaseId(Id)
{
    public Guid Id { get; init; } = Id;

   
}