using FluentValidator.Validation;
using System;
using System.Globalization;

namespace Munix.Domain.Entities
{
    public class CurrencyType : Entity
    {

        #region Constructors 
        protected CurrencyType() { }
        public CurrencyType(string name, string initials, decimal current, string cultureInfoName)
        {
            Name = name;
            Initials = initials;
            Current = current;
            CultureInfoName = cultureInfoName;


            AddNotifications(new ValidationContract()
                 .HasMinLen(Name, 2, "Name", "The currency name must be at least two characters")
                 .HasLen(Initials, 3, "Initials", "Invalid Initials")
                 .IsGreaterThan(Current, 0, "Current", "The current value must be greater than zero")
                 .IsNotNull(CultureInfo.GetCultureInfo(CultureInfoName), "CultureInfoName", "Culture info not found")
             );
        }

        #endregion

        #region Attributes  

 
        public string Name { get; set; }

        /// <summary>
        /// Initials Currency, Ex. USD, BRL
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// Current value of currency
        /// </summary>
        public decimal Current { get; set; }

        public string CultureInfoName { get; set; }


        #endregion

        #region Method

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
                .HasMinLen(Name, 2, "Name", "The currency name must be at least two characters")
                 .HasLen(Initials, 3, "Initials", "Invalid Initials")
                 .IsGreaterThan(Current, 0, "Current", "The current value must be greater than zero")
                 .IsNotNull(CultureInfo.GetCultureInfo(CultureInfoName), "CultureInfoName", "Culture info not found")
                 .IsNull(Deleted, "Deleted", "This currency is deleted and can't be changed")
             );
        }
        #endregion


    }
}
