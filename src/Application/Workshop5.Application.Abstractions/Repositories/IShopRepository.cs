using Workshop5.Application.Models.Shops;

namespace Workshop5.Application.Abstractions.Repositories;

public interface IShopRepository
{
    IEnumerable<Shop> GetAllShops();
}