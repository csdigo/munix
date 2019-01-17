using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;
using Munix.Infra.Connections;

namespace Munix.Infra.Repositories
{
    public class CurrencyTypeRepository : FastCrudRepository<CurrencyType>, ICurrencyTypeRepository
    {
        public CurrencyTypeRepository(MunixConnection connection)
            : base(connection)
        {
        }
    }
}
