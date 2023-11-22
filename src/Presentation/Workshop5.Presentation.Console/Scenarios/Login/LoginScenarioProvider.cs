using System.Diagnostics.CodeAnalysis;
using Workshop5.Application.Contracts.Users;

namespace Workshop5.Presentation.Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public LoginScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }
        
        scenario = new LoginScenario(_service);
        return true;
    }
}