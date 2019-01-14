using Munix.Domain.Contracts;
using System.Data.SqlClient;

namespace Munix.Infra.Connections
{
    public class MunixConnection : Connection<SqlConnection, SqlConnection>
    {
        public MunixConnection(string commandConnectionString) : base(commandConnectionString, commandConnectionString)
        {
        }
    }
}
