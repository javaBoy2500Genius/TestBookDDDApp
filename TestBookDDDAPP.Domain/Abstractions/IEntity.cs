namespace TestBookDDDAPP.Domain.Abstractions;

public interface IEntity
{
    void ClearAllEvents();

    IReadOnlyList<IDomainEvent> Events { get; }
}