using Workshop5.Application.Abstractions.Repositories;
using Workshop5.Application.Contracts.Users;

namespace Workshop5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username)
    {
        var user = _repository.FindUserByUsername(username);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }
}