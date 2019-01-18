using Munix.Infra.Mapping;
using System.Data.SqlClient;

namespace Munix.Infra.Connections
{
    public class MunixConnection : Connection<SqlConnection, SqlConnection>
    {
        public MunixConnection(string commandConnectionString) : base(commandConnectionString, commandConnectionString)
        {
            // Mapping entities for use FastCrud
            new ClientMap();
            new CurrencyTypeMap();
        }
    }
}
