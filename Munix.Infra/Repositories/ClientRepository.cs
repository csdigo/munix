using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;
using Munix.Infra.Connections;

namespace Munix.Infra.Repositories
{
    public class ClientRepository : FastCrudRepository<Client>, IClientRepository
    {
        public ClientRepository(MunixConnection connection) : base(connection)
        {
        }
    }
}
