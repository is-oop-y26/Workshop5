using Microsoft.Extensions.DependencyInjection;
using Workshop5.Presentation.Console.Scenarios.Login;

namespace Workshop5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        return collection;
    }
}