using Munix.Domain.Contracts;

namespace Munix.Domain.Commands.Command.CurrencyType
{
    public class CreateCurrencyTypeCommand : ICommand
    {
        /// <summary>
        /// Nome completo da moeda
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sigla da moeda
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// Valor atual da moeda
        /// </summary>
        public decimal Current { get; set; }

        /// <summary>
        /// Culture info utilizada para formatação 
        /// </summary>
        public string CultureInfo { get; set; }
    }
}
