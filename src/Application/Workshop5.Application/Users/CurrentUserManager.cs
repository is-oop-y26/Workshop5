using Workshop5.Application.Contracts.Users;
using Workshop5.Application.Models.Users;

namespace Workshop5.Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}