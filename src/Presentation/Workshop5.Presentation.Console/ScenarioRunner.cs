using Spectre.Console;

namespace Workshop5.Presentation.Console;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        var scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (var provider in _providers)
        {
            if (provider.TryGetScenario(out var scenario))
                yield return scenario;
        }
    }
}