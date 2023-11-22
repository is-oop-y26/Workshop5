using Microsoft.Extensions.DependencyInjection;
using Workshop5.Application.Contracts.Shops;
using Workshop5.Application.Contracts.Users;
using Workshop5.Application.Shops;
using Workshop5.Application.Users;

namespace Workshop5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IShopService, ShopService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}