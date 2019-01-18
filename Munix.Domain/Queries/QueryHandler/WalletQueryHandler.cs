using System.Collections.Generic;
using System.Linq;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.Result;

namespace Munix.Domain.Queries.QueryHandler
{
    public class WalletQueryHandler :
        IQueryHandleMultipleResult<GetAllQuery, WalletResult>,
        IQueryHandle<GetById, WalletResult>
    {
        public IWalletRepository _repository;

        public WalletQueryHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<WalletResult> Handle(GetAllQuery query)
        {
            // TODO Implement automapper
            return _repository
                .GetAll()
                .Select(x => new WalletResult());
        }

        public WalletResult Handle(GetById query)
        {
            // TODO Implement automapper
            var result = new WalletResult();

            var resulten = _repository
                .GetById(query.Id);

            return result;
        }
    }
}
