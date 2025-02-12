namespace TestBookDDDAPP.Domain.Abstractions;

public record Error(string Code, string Message)
{
    public static Error None = new Error(string.Empty, string.Empty);

    public static Error NullValue = new("error.NullValue", "Null value was provided");
}