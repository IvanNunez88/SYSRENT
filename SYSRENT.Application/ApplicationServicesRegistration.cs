using Microsoft.Extensions.DependencyInjection;

namespace SYSRENT.Application;

public static class ApplicationServicesRegistration
{

    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));

        return services;
    }

}
