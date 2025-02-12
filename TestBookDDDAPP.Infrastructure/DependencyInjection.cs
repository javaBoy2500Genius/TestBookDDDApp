using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TestBookDDDAPP.Domain.Abstractions;
using TestBookDDDAPP.Infrastructure.Repository;

namespace TestBookDDDAPP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasturcutre(
        this IServiceCollection builder,
        IConfiguration config
        )
    {

        builder.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        builder.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(AssemblyUsing).Assembly);
        });
        AddDbContext(builder, config );

        return builder;
    }

    private static void AddDbContext(IServiceCollection builder, IConfiguration config)
    {
        #region DbContext

        var connectionString = config.GetConnectionString("Database") ??
                               throw new ArgumentNullException("connection string not found");

        builder.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        builder.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<ApplicationDbContext>());

        #endregion
    }
}