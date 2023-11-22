using Workshop5.Application.Models.Users;

namespace Workshop5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}