using Microsoft.EntityFrameworkCore;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Infrastructure.Repository;

public class DbRepository<TEntity> :IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly ApplicationDbContext _context;
    private readonly  DbSet<TEntity> _db;
    public DbRepository(ApplicationDbContext context)
    {
        _context = context;
        _db = _context.Set<TEntity>();

    }

    public IQueryable<TEntity> GetAllAsQueryable(AggregationRoot<TEntity> filter)
    {
        return _db.Where(filter.GetFilter());
    }

    public async Task<List<TEntity>> GetAllAsync(AggregationRoot<TEntity> filter, CancellationToken cancellationToken = default)
    {
        return  _db.Where(filter.GetFilter()).ToList();
    }

    public async Task<TEntity?> GetAsync(AggregationRoot<TEntity> filter, CancellationToken cancellationToken = default)
    {
        return  _db.FirstOrDefault(filter.GetFilter());
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _db.AddAsync(entity, cancellationToken);
    }

  

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _db.Remove(entity);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _db.Update(entity);
    }



  
}