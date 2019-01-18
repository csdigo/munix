using FluentValidator.Validation;
using Munix.Domain.Enums;
using System;

namespace Munix.Domain.Entities
{
    public class Client : Entity
    {
        protected Client()
        { }

        /// <summary>
        /// Create a new Client
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="status"></param>
        public Client(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Status = ClientStatus.Active;
            Created = DateTime.Now;
            Updated = Created;

            AddNotifications(
                new ValidationContract()
                    .IsEmail(email, "Email", "Invalid E-mail")
                    .HasMinLen(FirstName, 2, "FirstName", "First name is required at least 2 letters")
                    .HasMinLen(LastName, 2, "LastName", "Last name is required at least 2 letters")
            );
        }

        #region Attributes


        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public ClientStatus Status { get; private set; }




        #endregion

        internal void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Updated = DateTime.Now;

            AddNotifications(
                new ValidationContract()
                    .IsEmail(email, "Email", "Invalid E-mail")
                    .HasMinLen(FirstName, 2, "FirstName", "First name is required at least 2 letters")
                    .HasMinLen(LastName, 2, "LastName", "Last name is required at least 2 letters")
            );
        }

        internal void Inative()
        {
            AddNotifications(
                new ValidationContract()
                    .AreNotEquals(Status, ClientStatus.Delete, "Status", "It is not allowed to inactivate a deleted client")
                    .AreNotEquals(Status, ClientStatus.Inative, "Status", "This client is already inactive")
            );
            Updated = Created;
            Status = ClientStatus.Inative;
        }

        internal void Delete()
        {
            AddNotifications(
               new ValidationContract()
                   .AreNotEquals(Status, ClientStatus.Delete, "Status", "This client is already delete")
           );

            Deleted = DateTime.Now;
            Updated = Created;
            Status = ClientStatus.Delete;
        }
    }
}
