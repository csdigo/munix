using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }
    }
}
