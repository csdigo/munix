namespace Munix.Domain.Contracts
{
    public interface ICommandHandler<TCommand, TResultComand> 
        where TCommand : ICommand
        where TResultComand : IResultCommand

    {
        TResultComand Handle(TCommand command);
    }
}
