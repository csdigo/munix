using System;
using System.Linq;
using Dapper.FastCrud;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;
using Munix.Infra.Connections;

namespace Munix.Infra.Repositories
{
    public class WalletRepository : FastCrudRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(MunixConnection connection) : base(connection)
        {
        }

        public override Wallet GetById(Guid id)
        {
            var result = Connection.Query.Find<Wallet>(
                x => x.Where($"{nameof(Wallet.Id):C} = @id")
                .WithParameters(new { id })
                .Include<Client>()
                .Include<CurrencyType>()
            ).FirstOrDefault();
            return result;
        }
    }
}
