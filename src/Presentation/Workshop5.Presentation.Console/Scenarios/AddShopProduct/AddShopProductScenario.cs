using Spectre.Console;
using Workshop5.Application.Contracts.Shops;
using Workshop5.Application.Models.Shops;

namespace Workshop5.Presentation.Console.Scenarios.AddShopProduct;

public class AddShopProductScenario : IScenario
{
    private readonly IShopService _shopService;

    public AddShopProductScenario(IShopService shopService)
    {
        _shopService = shopService;
    }

    public string Name => "Add shop product";

    public void Run()
    {
        var shops = _shopService.GetAllShops();

        var selector = new SelectionPrompt<Shop>()
            .Title("Select shop")
            .AddChoices(shops)
            .UseConverter(x => x.Name);

        var shop = AnsiConsole.Prompt(selector);
        
        AnsiConsole.WriteLine($"You selected {shop.Name}");

        AnsiConsole.Ask<string>("");
    }
}