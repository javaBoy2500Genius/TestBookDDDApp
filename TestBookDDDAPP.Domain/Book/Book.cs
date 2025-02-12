using Microsoft.VisualBasic.CompilerServices;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Domain.Book;

public sealed class Book : Entity<BookId>
{
    public Book()
    {
        
    }
    public Book(BookId Id,Author author, Name name, Description description, Money price): base(Id)
    {
        Author=author;
        Name=name;
        Description=description;
        Price = price;
    }
  
    public Author Author { get; private set; }

    public Name Name { get; private set; }
    public Description Description{ get; private set; }


    public Money Price { get; private set; }
}