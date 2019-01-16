using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Commands.Command.Client
{
    public class DeleteClientCommand : ICommand
    {
        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
