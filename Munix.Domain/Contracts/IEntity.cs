using System;

namespace Munix.Domain.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
