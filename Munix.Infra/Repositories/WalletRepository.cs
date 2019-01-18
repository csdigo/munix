using System.Data.SqlClient;
using Munix.Domain.Entities;
using Munix.Infra.Connections;

namespace Munix.Infra.Repositories
{
    public class WalletRepository : FastCrudRepository<Wallet>, ICrudRepository
    {
        public WalletRepository(MunixConnection connection) : base(connection)
        {
        }
    }
}
