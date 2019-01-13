namespace Munix.Domain.Contracts
{
    public interface ICommandHandle<TCommand, TResultComand> 
        where TCommand : ICommand
        where TResultComand : IResultCommand

    {
        TResultComand Handle(TCommand command);
    }
}
