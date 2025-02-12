using System.Linq.Expressions;
using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Domain.Book;

namespace TestBookDDDApp.Book.Predicate;

public class GetBookIdPredicate(BookId id) :AggregationRoot<TestBookDDDAPP.Domain.Book.Book>
{
    protected override Expression<Func<TestBookDDDAPP.Domain.Book.Book, bool>> Predicate => book => book.Id == id;
}