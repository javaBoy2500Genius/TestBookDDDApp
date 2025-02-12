using TestBookDDDApp.Abstraction.Messaging;
using TestBookDDDApp.Book.CreateBook.DTO;

namespace TestBookDDDApp.Book.CreateBook;

public record CreateBookCommand(BookCreateDto value) : ICommand<TestBookDDDAPP.Domain.Book.Book>;
    
