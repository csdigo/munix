using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.FastCrud;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Infra.Connections;

namespace Munix.Infra.Repositories
{
    public class FastCrudRepository<TEntity> : ICrudRepository<TEntity>
        where TEntity : IEntity
    {

        Connection<SqlConnection, SqlConnection> _connection;

        public FastCrudRepository(Connection<SqlConnection, SqlConnection> connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Return All
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _connection.Query.Find<TEntity>();
        }

        /// <summary>
        /// Return by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(Guid id)
        {
            return _connection.Query.Find<TEntity>(x => x.Where($"Id  = @id").WithParameters(new { id })).FirstOrDefault();
        }

        public void Insert(TEntity obj)
        {
            _connection.Command.Insert(obj);
        }

        public bool Update(TEntity obj)
        {
            return _connection.Command.Update(obj);
        }
    }
}
