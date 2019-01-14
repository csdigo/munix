using System.Collections.Generic;
using System.Linq;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.Result;

namespace Munix.Domain.Queries.QueryHandle
{
    public class ClientQueryHandle : IQueryHandleMultipleResult<GetAllQuery, ClientResult>
    {
        IClientRepository _clientRepository;

        public ClientQueryHandle(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<ClientResult> Handle(GetAllQuery query)
        {
            // TODO Colocar o automapper
            return _clientRepository
                .GetAll()
                .Select(x => new ClientResult());
        }
    }
}
