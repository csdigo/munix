using Munix.Domain.Enums;
using System;

namespace Munix.Domain.Entities
{
    public class Wallet : Entity
    {

        public Guid ClientId { get; set; }
        public Guid CurrencyTypeId { get; set; }

        public WalletStatus Status { get; set; }
        public Client Client { get; set; }
        public CurrencyType CurrencyType { get; set; }

    }
}
