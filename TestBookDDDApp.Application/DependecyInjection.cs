namespace TestBookDDDApp;

public static class DependencyInjection
{

    public static IServiceCollection AddApplicationDeps(this IServiceCollection services)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(AssemlyUse).Assembly);
        });

        return services;
    }
    
}