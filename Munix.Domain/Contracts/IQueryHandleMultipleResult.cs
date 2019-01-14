using System.Collections.Generic;

namespace Munix.Domain.Contracts
{
    public interface IQueryHandleMultipleResult<TQuery, out TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        IEnumerable<TResult> Handle(TQuery query);
    }
}
