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

        protected Connection<SqlConnection, SqlConnection> Connection;

        public FastCrudRepository(Connection<SqlConnection, SqlConnection> connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Return All
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Connection.Query.Find<TEntity>();
        }

        /// <summary>
        /// Return by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(Guid id)
        {
            return Connection.Query.Find<TEntity>(x => x.Where($"Id  = @id").WithParameters(new { id })).FirstOrDefault();
        }

        public virtual void Insert(TEntity obj)
        {
            Connection.Command.Insert(obj);
        }

        public virtual bool Update(TEntity obj)
        {
            return Connection.Command.Update(obj);
        }
    }
}
