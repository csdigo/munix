namespace Munix.Domain.Entities
{
    public class Wallet : Entity
    {
        public CurrencyType Currency { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public CurrencyType CurrencyType { get; set; }
    }
}
