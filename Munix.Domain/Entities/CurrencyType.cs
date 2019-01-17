using FluentValidator.Validation;
using System;
using System.Globalization;

namespace Munix.Domain.Entities
{
    public class CurrencyType : Entity
    {

        #region Construtores
        protected CurrencyType() { }
        public CurrencyType(string name, string initials, decimal current, string cultureInfoName)
        {
            Name = name;
            Initials = initials;
            Current = current;
            CultureInfoName = cultureInfoName;


            AddNotifications(new ValidationContract()
                 .HasMinLen(Name, 2, "Name", "O nome da moeda tem que ter pelo menos dois caracteres")
                 .HasLen(Initials, 3, "Initials", "Sigla inválida")
                 .IsGreaterThan(Current, 0, "Current", "O valor atual tem que ser maior que zero")
                 .IsNotNull(CultureInfo.GetCultureInfo(CultureInfoName), "CultureInfoName", "Culture info não encontrado")
             );
        }

        #endregion

        #region Atributos  

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
        public string CultureInfoName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Deleted { get; set; }

        #endregion

        #region Método

        internal void Delete()
        {
            Deleted = DateTime.Now;
        }

        internal void Update(string name, string initials, decimal current, string cultureInfoName)
        {
            Name = name;
            Initials = initials;
            Current = current;
            CultureInfoName = cultureInfoName;

            AddNotifications(new ValidationContract()
                 .HasMinLen(Name, 2, "Name", "O nome da moeda tem que ter pelo menos dois caracteres")
                 .HasLen(Initials, 3, "Initials", "Sigla inválida")
                 .IsGreaterThan(Current, 0, "Current", "O valor atual tem que ser maior que zero")
                 .IsNotNull(CultureInfo.GetCultureInfo(CultureInfoName), "CultureInfoName", "Culture info não encontrado")
                 .IsNull(Deleted, "Deleted", "Essa moeda está deletada e não pode ser alterada")
             );
        }
        #endregion


    }
}
