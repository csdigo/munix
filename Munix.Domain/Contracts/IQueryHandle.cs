namespace Munix.Domain.Contracts

{
    public interface IQueryHandle<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Handle(TQuery query);
    }
}
