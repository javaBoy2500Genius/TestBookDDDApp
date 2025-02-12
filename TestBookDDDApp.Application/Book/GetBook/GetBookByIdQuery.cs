using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDAPP.Domain.Book;

namespace TestBookDDDApp.Book.GetBook;

public record GetBookByIdQuery(BookId bookId) : IQuery<TestBookDDDAPP.Domain.Book.Book>;
