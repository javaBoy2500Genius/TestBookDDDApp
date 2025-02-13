using MediatR;
using TestBookDDDApp.Abstraction.Behaivor;

namespace TestBookDDDApp;

public static class DependencyInjection
{

    public static IServiceCollection AddApplicationDeps(this IServiceCollection services)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(AssemlyUse).Assembly);
           
        });

        services.RegistryAddBehaviors();


        return services;
    }

    private static  IServiceCollection RegistryAddBehaviors(this IServiceCollection services)
    {
        services.AddBehaviors( typeof(LogingBehaivor<,>));
        services.AddBehaviors( typeof(UnitOfWorkBehaivor<,>));
        return services;
    }

    private static IServiceCollection AddBehaviors(this IServiceCollection service, Type type)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), type);

        return service;
    }
}