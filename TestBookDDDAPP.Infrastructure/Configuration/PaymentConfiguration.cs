using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestBookDDDAPP.Domain.Payments;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDAPP.Infrastructure.Configuration;

public class PaymentConfiguration: IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, g => new PaymentId(g));

        builder.OwnsOne(p => p.Amount, build =>
        {
            build.Property(m => m.Currency)
                .HasConversion(c => c.Code, code => Currency.FromCode(code));

        });




    }
}