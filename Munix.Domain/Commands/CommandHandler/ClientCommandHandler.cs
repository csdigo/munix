using Munix.Domain.Commands.Command.Client;
using Munix.Domain.Contracts;
using Munix.Domain.Commands.Result;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;

namespace Munix.Domain.Commands.CommandHandler
{
    public class ClientCommandHandler : 
        ICommandHandler<CreateClientCommand, ResultCommand>,
        ICommandHandler<UpdateClientCommand, ResultCommand>,
        ICommandHandler<DeleteClientCommand, ResultCommand>
    {

        IClientRepository _repository;

        public ClientCommandHandler(IClientRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Create new Client
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ResultCommand Handle(CreateClientCommand command)
        {
            var result = new ResultCommand();

            var client = new Client(command.FirstName, command.LastName, command.Email);

            // Repassando a notificação para o resultado
            result.AddNotifications(client);

            if (result.Valid)
                _repository.Insert(client);

            return result;
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ResultCommand Handle(UpdateClientCommand command)
        {
            var result = new ResultCommand();

            var client = _repository.GetById(command.Id);

            client.Update(command.FirstName, command.LastName, command.Email);
          
            result.AddNotifications(client);

            if (result.Valid)
                _repository.Update(client);

            return result;
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ResultCommand Handle(DeleteClientCommand command)
        {
            var result = new ResultCommand();

            // Return client by Id
            var client = _repository.GetById(command.Id);

            client.Delete();


            result.AddNotifications(client);

            if (result.Valid)
                _repository.Update(client);

            return result;

        }
    }
}
