namespace Workshop5.Application.Contracts.Users;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;
}