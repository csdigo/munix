namespace Munix.Domain.Entities
{
    public class Wallet : Entity
    {
        // TODO Criar uma entidade para salvar o valor do dia
        public CurrencyType Currency { get; set; }

        public int ClientId { get; set; }

        /// <summary>
        /// Cliente da carteira
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Moeada da carteira
        /// </summary>
        public CurrencyType CurrencyType { get; set; }
    }
}
