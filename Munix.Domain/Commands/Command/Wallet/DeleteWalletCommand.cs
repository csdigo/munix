using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Commands.Command.Wallet
{
    public class DeleteWalletCommand : ICommand
    {
        public DeleteWalletCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
