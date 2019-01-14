using System;
using System.Collections.Generic;

namespace Munix.Domain.Contracts.Repositories
{
    /// <summary>
    /// Interface para implementação de CRUD Básico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudRepository<T> : IRepository
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Insert(T obj);

        bool Update(T obj);

    }
}
