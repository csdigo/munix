using Dapper.FastCrud;
using Munix.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Munix.Infra.Mapping
{
    public class ClientMap
    {
        public ClientMap()
        {
            OrmConfiguration.RegisterEntity<Client>()
               .SetTableName("Clients")
               .SetProperty(c => c.Id,
                    prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.None))
                .SetProperty(c => c.FirstName, prop => prop.SetDatabaseColumnName("FirstName"))
                .SetProperty(c => c.LastName, prop => prop.SetDatabaseColumnName("LastName"))
                .SetProperty(c => c.Email, prop => prop.SetDatabaseColumnName("Email"))
                .SetProperty(c => c.Status, prop => prop.SetDatabaseColumnName("Status"))
                .SetProperty(c => c.Created, prop => prop.SetDatabaseColumnName("Created"))
                .SetProperty(c => c.Updated, prop => prop.SetDatabaseColumnName("Updated"))
                .SetProperty(c => c.Deleted, prop => prop.SetDatabaseColumnName("Deleted"))
                ;


        }
    }
}
