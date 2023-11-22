using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;
using Workshop5.Application.Abstractions.Repositories;
using Workshop5.Application.Models.Shops;

namespace Workshop5.Infrastructure.DataAccess.Repositories;

public class ShopRepository : IShopRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public ShopRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Shop> GetAllShops()
    {
        const string sql = """
        select shop_id, shop_name
        from shops
        """;

        var connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Shop(
                reader.GetInt64(0),
                reader.GetString(1));
        }
    }
}