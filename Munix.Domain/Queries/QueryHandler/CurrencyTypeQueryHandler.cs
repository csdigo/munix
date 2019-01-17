using System.Collections.Generic;
using System.Linq;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.Result;

namespace Munix.Domain.Queries.QueryHandler
{
    public class CurrencyTypeQueryHandler :
         IQueryHandleMultipleResult<GetAllQuery, CurrencyTypeResult>,
        IQueryHandle<GetById, CurrencyTypeResult>
    {
        ICurrencyTypeRepository _repository;

        public CurrencyTypeQueryHandler(ICurrencyTypeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CurrencyTypeResult> Handle(GetAllQuery query)
        {
            return _repository.GetAll().Select(x => new CurrencyTypeResult());
        }

        public CurrencyTypeResult Handle(GetById query)
        {
            // TODO Colocar o automapper
            var result = new CurrencyTypeResult();

            var resulten = _repository
                .GetById(query.Id);

            return result;
        }
    }
}
