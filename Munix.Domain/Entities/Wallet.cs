using FluentValidator.Validation;
using Munix.Domain.Enums;
using System;

namespace Munix.Domain.Entities
{
    public class Wallet : Entity
    {
        protected Wallet() { }

        public Wallet(Client client, CurrencyType currencyType)
        {
            Id = Guid.NewGuid();
            Client = client;
            CurrencyType = currencyType;
            
            ClientId = (Client?.Id).GetValueOrDefault();
            CurrencyTypeId = (CurrencyType?.Id).GetValueOrDefault();
            Status = WalletStatus.Active;
            Created = DateTime.Now;

            AddNotifications(new ValidationContract()
                .IsNotNull(ClientId, "ClientId", "Client not found")
                .IsNotNull(ClientId, "CurrencyTypeId", "CurrencyType not found")
            );

        }

        public Guid Id { get; private set; }
        public Guid ClientId { get; set; }
        public Guid CurrencyTypeId { get; set; }

        public WalletStatus Status { get; set; }
        public Client Client { get; set; }
        public CurrencyType CurrencyType { get; set; }

        internal void Update()
        {
            AddNotification("Client", "It is not permit change client of the Wallet");
            AddNotification("CurrencyType", "It is not permit change currency type of the Wallet");
        }

        internal void Delete()
        {
            Deleted = DateTime.Now;
            Status = WalletStatus.Delete;
        }
    }
}
