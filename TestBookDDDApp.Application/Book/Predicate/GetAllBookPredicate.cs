using System.Linq.Expressions;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDApp.Book.Predicate;

public class GetAllBookPredicate :AggregationRoot<TestBookDDDAPP.Domain.Book.Book>
{
    protected override Expression<Func<TestBookDDDAPP.Domain.Book.Book, bool>> Predicate => b => true;
}