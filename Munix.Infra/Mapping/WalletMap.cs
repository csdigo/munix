using Dapper.FastCrud;
using Munix.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Munix.Infra.Mapping
{
    public class WalletMap
    {
        public WalletMap()
        {
            OrmConfiguration.RegisterEntity<Wallet>()
              .SetTableName("Wallets")
              .SetProperty(c => c.Id,
                   prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.None))
               .SetProperty(c => c.ClientId, prop => prop.SetDatabaseColumnName("ClientId").SetChildParentRelationship<Client>("Client"))
               .SetProperty(c => c.CurrencyTypeId, prop => prop.SetDatabaseColumnName("CurrencyTypeId").SetChildParentRelationship<CurrencyType>("CurrencyType"))
               .SetProperty(c => c.Status, prop => prop.SetDatabaseColumnName("Status"))
               ;
        }
    }
}
