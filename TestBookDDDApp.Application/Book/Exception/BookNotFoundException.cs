using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Book.Exception;

public sealed class BookNotFoundException
{
    public static Error GetError => new Error("404", "book with specify id not found");
}