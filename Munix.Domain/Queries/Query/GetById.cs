using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Queries.Query
{
    public class GetById : IQuery
    {
        public GetById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
