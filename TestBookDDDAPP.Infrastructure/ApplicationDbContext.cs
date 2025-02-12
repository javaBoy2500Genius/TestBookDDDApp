using MediatR;
using Microsoft.EntityFrameworkCore;
using TestBookDDDAPP.Domain.Abstractions;

namespace TestBookDDDAPP.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyUsing).Assembly);
        base.OnModelCreating(modelBuilder);
    }


    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {

            var result = await base.SaveChangesAsync(cancellationToken);

            var events = ChangeTracker
                .Entries<IEntity>()
                .Select(entry => entry.Entity)
                .SelectMany((ent =>
                {
                    var events = ent.Events;
                    ent.ClearAllEvents();
                    return events;
                }));

            foreach (var ev in events )
            {
                await _publisher.Publish(ev);
            }




            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}