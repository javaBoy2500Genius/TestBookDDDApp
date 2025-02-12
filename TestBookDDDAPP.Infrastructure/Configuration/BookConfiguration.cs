using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using TestBookDDDAPP.Domain.Book;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Infrastructure.Configuration;

public class BookConfiguration :IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasConversion(x => x.Id, y => new BookId(y));

        builder.OwnsOne(b => b.Author);

        builder.Property(b => b.Name)
            .HasMaxLength(100)
            .HasConversion(n => n.name, str => new Name(str));


        builder.Property(b => b.Description)
            .HasMaxLength(200)
            .HasConversion(d => d.description, str => new Description(str));


        builder.OwnsOne(b => b.Price, bx =>
        {
            bx.Property(b => b.Currency)
                .HasConversion(cur => cur.Code, str => Currency.FromCode(str));

        });


    }
}