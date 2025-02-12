using System.Linq.Expressions;

namespace TestBookDDDAPP.Domain.Abstractions;

public abstract class AggregationRoot<TEntity> where TEntity : IEntity
{
    protected abstract Expression< Func<TEntity, bool>> Predicate { get; }

    public Expression< Func<TEntity, bool>> GetFilter() => Predicate;
}
