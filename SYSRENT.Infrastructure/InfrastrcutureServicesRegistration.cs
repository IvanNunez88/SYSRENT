using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;
using SYSRENT.Infrastructure.Context;
using SYSRENT.Infrastructure.Repository;

namespace SYSRENT.Infrastructure;

public static class InfrastrcutureServicesRegistration
{

    public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISqlDbConnection, SqlDapperConnection>();
        services.AddScoped<IHorarioRepository, HorarioRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
