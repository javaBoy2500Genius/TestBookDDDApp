using MediatR;

namespace TestBookDDDAPP.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity where TEntityId : BaseId
{
    protected Entity(TEntityId id) => Id = id;

    protected Entity()
    {

    }

    public TEntityId Id { get; init; }

    public void ClearAllEvents()
    {
        domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent ev)
    {
        domainEvents.Add(ev);
    }

    public IReadOnlyList<IDomainEvent> Events => domainEvents.AsReadOnly();

    private List<IDomainEvent> domainEvents { get; set; } = new();


    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TEntityId> entity)
        {
            return false;
        }

        if (ReferenceEquals(this, entity))
        {
            return true;
        }


        return Id.Equals(entity.Id);

    }

    public static bool operator ==(Entity<TEntityId>? a, Entity<TEntityId>? b)
    {
        if (ReferenceEquals(a, b)) return true;

        if(a is null || b is null) return false;


        return a.Id.Equals(b.Id);
    }

    public static bool operator !=(Entity<TEntityId>? a, Entity<TEntityId>? b)
    {
        return !(a == b);
    }
}





