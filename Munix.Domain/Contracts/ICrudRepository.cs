using System;
using System.Collections.Generic;

namespace Munix.Domain.Contracts.Repositories
{
    /// <summary>
    /// Interface for implementation basic CRUD
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
