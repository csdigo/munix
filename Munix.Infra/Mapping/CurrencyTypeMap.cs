using Dapper.FastCrud;
using Munix.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Munix.Infra.Mapping
{
    public class CurrencyTypeMap : Entity
    {
        public CurrencyTypeMap()
        {
            OrmConfiguration.RegisterEntity<CurrencyType>()
              .SetTableName("CurrencyTypes")
              .SetProperty(c => c.Id,
                   prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.None))
               .SetProperty(c => c.Name, prop => prop.SetDatabaseColumnName("Name"))
               .SetProperty(c => c.Initials, prop => prop.SetDatabaseColumnName("Initials"))
               .SetProperty(c => c.Current, prop => prop.SetDatabaseColumnName("Current"))
               .SetProperty(c => c.CultureInfoName, prop => prop.SetDatabaseColumnName("CultureInfoName"))
               .SetProperty(c => c.Created, prop => prop.SetDatabaseColumnName("Created"))
               .SetProperty(c => c.Updated, prop => prop.SetDatabaseColumnName("Updated"))
               .SetProperty(c => c.Deleted, prop => prop.SetDatabaseColumnName("Deleted"))
               ;
        }
    }
}
