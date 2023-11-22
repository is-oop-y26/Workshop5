using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Workshop5.Application.Abstractions.Repositories;
using Workshop5.Infrastructure.DataAccess.Plugins;
using Workshop5.Infrastructure.DataAccess.Repositories;

namespace Workshop5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IShopRepository, ShopRepository>();

        return collection;
    }
}