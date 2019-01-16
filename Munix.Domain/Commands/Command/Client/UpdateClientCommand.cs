using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Commands.Command.Client
{
    public class UpdateClientCommand : CreateClientCommand
    {
        public Guid Id { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
