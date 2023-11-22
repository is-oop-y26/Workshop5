using System.Diagnostics.CodeAnalysis;

namespace Workshop5.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}