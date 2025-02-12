using TestBookDDDApp.Abstraction.Messaging;

namespace TestBookDDDApp.Book.GetBook;

public record GetAllBookQuery() : IQuery<List<TestBookDDDAPP.Domain.Book.Book>>;
