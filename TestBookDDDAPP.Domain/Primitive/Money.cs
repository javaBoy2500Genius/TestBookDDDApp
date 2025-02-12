namespace TestBookDDDAPP.Domain.Primitive;

public record Money(Currency Currency, decimal  Amount)
{
    public static Money operator +(Money value1, Money value2)
    {
        if (value1.Currency != value2.Currency)
            throw new ArgumentException("currency must be equals");

        return value1 with { Amount = value1.Amount + value2.Amount };
    }  
    
    public static Money operator -(Money value1, Money value2)
    {
        if (value1.Currency != value2.Currency)
            throw new ArgumentException("currency must be equals");

        return value1 with { Amount = value1.Amount - value2.Amount };
    }

    public static Money Zero() => new(Currency.None, 0);
    public static Money Zero(Currency currency) => new(currency, 0);

    public bool IsZero()=>this==Zero(Currency);



}