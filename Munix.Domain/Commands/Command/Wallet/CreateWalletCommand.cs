using System;
using Munix.Domain.Contracts;

namespace Munix.Domain.Commands.Command.Wallet
{
    public class CreateWalletCommand : ICommand
    {
        public Guid ClientId { get;  set; }
        public Guid CurrencyTypeId { get; set; }
    }
}
