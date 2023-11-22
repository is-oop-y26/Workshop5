using Workshop5.Application.Models.Users;

namespace Workshop5.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}