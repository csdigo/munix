using Munix.Domain.Contracts;
using System;

namespace Munix.Infra.Connections
{
    public class Connection<TCommandConnection, TQueryConnection> : IConnection

    {
        /// <summary>
        /// Construtor quando o banco de dados de escrita é diferente de leitura
        /// </summary>
        /// <param name="commandConnectionString"></param>
        /// <param name="queryconnectionString"></param>
        public Connection(string commandConnectionString, string queryconnectionString)
        {
            _commandConnectionString = commandConnectionString;
            _queryconnectionString = queryconnectionString;
        }

        /// <summary>
        /// Construtor quando o de leitura é o mesmo de leitura
        /// </summary>
        /// <param name="commandConnectionString"></param>
        public Connection(string commandConnectionString)
        {
            _commandConnectionString = commandConnectionString;
            _queryconnectionString = commandConnectionString;
        }

        string _commandConnectionString { get; set; }
        string _queryconnectionString { get; set; }


        TCommandConnection _commandConnection;
        TQueryConnection _queryConnection;

        public TCommandConnection Command
        {
            get
            {
                // TODO Usar o ??
                return _commandConnection = _commandConnection != null ? _commandConnection : (TCommandConnection)Activator.CreateInstance(typeof(TCommandConnection), _commandConnectionString);
            }
        }
        public TQueryConnection Query
        {
            get
            {
                // TODO Usar o ??
                return _queryConnection = _queryConnection != null ? _queryConnection : (TQueryConnection)Activator.CreateInstance(typeof(TQueryConnection), _queryconnectionString);
            }
        }


    }
}
