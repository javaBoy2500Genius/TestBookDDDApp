using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDApp.Book.CreateBook.DTO;

public record BookCreateDto(Author author, Name name, Description description, Money price);