// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Workshop5.Application.Extensions;
using Workshop5.Infrastructure.DataAccess.Extensions;
using Workshop5.Presentation.Console;
using Workshop5.Presentation.Console.Extensions;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

var provider = collection.BuildServiceProvider();
using var scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

var scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}