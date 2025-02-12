using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using TestBookDDDAPP.Domain.Book;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Customers;
using TestBookDDDAPP.Domain.Order;
using TestBookDDDAPP.Domain.Payments;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Infrastructure.Configuration;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .HasConversion(o => o.Value, str => new OrderId(str));

        builder.OwnsMany(o => o.Items, op =>
        {
            op.WithOwner();
            op.Property(i => i.Count)
                .IsRequired();

            op.HasOne(i => i.Book)
                .WithMany()
                .HasForeignKey("BookId");

            op.Property<BookId>("BookId")
                .HasConversion(
                    id => id.Value,
                    guid => new BookId(guid));
           
        });

        builder.Ignore(o => o.TotalPrice);



        builder.HasOne(o => o.Customer)
            .WithOne()
            .HasForeignKey<Order>(o=>o.CustomerId)
            .HasPrincipalKey<Customer>(c => c.Id);

        builder.Property(o=>o.CustomerId)
            .HasConversion(id => id.Value, g => new CustomerId(g));


        builder.HasOne(o => o.Payment)
            .WithOne()
            .HasForeignKey<Order>(o => o.PaymentId)
            .HasPrincipalKey<Payment>(c => c.Id);

        builder.Property(o => o.PaymentId)
            .HasConversion(id => id.Value, g => new PaymentId(g));


    }
}