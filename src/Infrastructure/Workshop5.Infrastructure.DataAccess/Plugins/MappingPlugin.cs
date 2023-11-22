using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;
using Workshop5.Application.Models.Users;

namespace Workshop5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>();
    }
}