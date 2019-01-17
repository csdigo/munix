using FluentValidator.Validation;
using Munix.Domain.Enums;
using System;

namespace Munix.Domain.Entities
{
    public class Client : Entity
    {
        // Construtor vazio para o uso do FastCrud e Entity
        protected Client()
        { }

        /// <summary>
        /// Criando um cliente
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
                    .IsEmail(email, "Email", "E-mail inválido")
                    .HasMinLen(FirstName, 2, "FirstName", "O primeiro nome é necessário ter pelo menos 2 letras")
                    .HasMinLen(LastName, 2, "LastName", "O ultimo nome é necessário ter pelo menos 2 letras")
            );
        }

        #region Atributos


        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public ClientStatus Status { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime? Deleted { get; private  set; }

        public DateTime Updated { get; private set; }


        #endregion

        internal void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Updated = DateTime.Now;

            AddNotifications(
                new ValidationContract()
                    .IsEmail(email, "Email", "E-mail inválido")
                    .HasMinLen(FirstName, 2, "FirstName", "O primeiro nome é necessário ter pelo menos 2 letras")
                    .HasMinLen(LastName, 2, "LastName", "O ultimo nome é necessário ter pelo menos 2 letras")
            );
        }

        internal void Inative()
        {
            AddNotifications(
                new ValidationContract()
                    .AreNotEquals(Status, ClientStatus.Delete, "Status", "Não é permitido inativar um cliente deletado")
                    .AreNotEquals(Status, ClientStatus.Inative, "Status", "Este cliente já está inativo")
            );
            Updated = Created;
            Status = ClientStatus.Inative;
        }

        internal void Delete()
        {
            AddNotifications(
               new ValidationContract()
                   .AreNotEquals(Status, ClientStatus.Delete, "Status", "Este cliente já está deletado")
           );

            Deleted = DateTime.Now;
            Updated = Created;
            Status = ClientStatus.Delete;
        }
    }
}
