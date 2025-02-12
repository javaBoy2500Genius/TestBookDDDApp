namespace TestBookDDDAPP.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : IEntity
{

    IQueryable<TEntity> GetAllAsQueryable(AggregationRoot<TEntity> val);
    Task<List<TEntity>> GetAllAsync(AggregationRoot<TEntity> val, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(AggregationRoot<TEntity> val, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity deleteEntity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity update, CancellationToken cancellationToken = default);
    
}