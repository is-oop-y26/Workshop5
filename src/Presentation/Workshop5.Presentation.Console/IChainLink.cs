namespace Workshop5.Presentation.Console;

public interface IChainLink<TRequest, TResult>
{
    TResult Handle(TRequest request);

    IChainLink<TRequest, TResult> AddNext(IChainLink<TRequest, TResult> link);
}