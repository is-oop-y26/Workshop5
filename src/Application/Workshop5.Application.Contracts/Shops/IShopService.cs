using Workshop5.Application.Models.Shops;

namespace Workshop5.Application.Contracts.Shops;

public interface IShopService
{
    IEnumerable<Shop> GetAllShops();
}