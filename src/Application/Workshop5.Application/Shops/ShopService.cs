using Workshop5.Application.Abstractions.Repositories;
using Workshop5.Application.Contracts.Shops;
using Workshop5.Application.Models.Shops;

namespace Workshop5.Application.Shops;

internal class ShopService : IShopService
{
    private readonly IShopRepository _repository;

    public ShopService(IShopRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Shop> GetAllShops()
    {
        return _repository.GetAllShops();
    }
}