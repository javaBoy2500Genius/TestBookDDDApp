namespace TestBookDDDAPP.Domain.Primitive;

public record Currency(string Code)
{
    internal static Currency None => new Currency("None");
    internal static Currency Usd => new Currency("USD");

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
               throw new ApplicationException("code not valid");
    }

    public static IReadOnlyList<Currency> All = [None,Usd];

}