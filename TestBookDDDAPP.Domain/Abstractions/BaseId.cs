namespace TestBookDDDAPP.Domain.Abstractions;

public abstract class BaseId : IEquatable<BaseId>
{
    public Guid Value { get; init; }

    protected BaseId(Guid value)
    {
        Value = value;
    }



    public override bool Equals(object? obj)
    {
        if (obj is BaseId other)
        {
            return other.Value == Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(BaseId? a, BaseId? b) => a?.Equals(b) == true;

    public static bool operator !=(BaseId? a, BaseId? b) => !(a == b);


    public bool Equals(BaseId? other)
    {
        return other is not null && Value == other.Value;
    }
}