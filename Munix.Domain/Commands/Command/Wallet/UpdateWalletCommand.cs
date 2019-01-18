using System;

namespace Munix.Domain.Commands.Command.Wallet
{
    public class UpdateWalletCommand : CreateWalletCommand
    {
        public Guid Id { get; set; }
    }
}
