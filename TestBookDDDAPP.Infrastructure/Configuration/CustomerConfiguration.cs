using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Customers;

namespace TestBookDDDAPP.Infrastructure.Configuration;

public class CustomerConfiguration :IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(id => id.Value, g => new CustomerId(g));

        builder.Property(c => c.Name)
            .HasConversion(n => n.name, str => new Name(str))
            .HasMaxLength(100);

        builder.Property(c => c.Email).IsRequired()
            .HasMaxLength(100);


        builder.OwnsOne(c => c.Address);

    }
}