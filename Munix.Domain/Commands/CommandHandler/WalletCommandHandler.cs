using Munix.Domain.Commands.Command.Wallet;
using Munix.Domain.Commands.Result;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;

namespace Munix.Domain.Commands.CommandHandler
{
    public class WalletCommandHandler :
        ICommandHandler<CreateWalletCommand, ResultCommand>,
        ICommandHandler<UpdateWalletCommand, ResultCommand>,
        ICommandHandler<DeleteWalletCommand, ResultCommand>
    {

        IWalletRepository _repository;
        IClientRepository _clientRepository;
        ICurrencyTypeRepository _currencyTypeRepository;

        public WalletCommandHandler(IWalletRepository repository, IClientRepository clientRepository, ICurrencyTypeRepository currencyTypeRepository)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _currencyTypeRepository = currencyTypeRepository;
        }

        public ResultCommand Handle(CreateWalletCommand command)
        {
            var result = new ResultCommand();

            var client = _clientRepository.GetById(command.ClientId);
            var currencyType = _currencyTypeRepository.GetById(command.CurrencyTypeId);

            var wallet = new Wallet(client, currencyType);

            result.AddNotifications(wallet);

            if (result.Valid)
                _repository.Insert(wallet);

            return result;
        }

        public ResultCommand Handle(UpdateWalletCommand command)
        {
            var result = new ResultCommand();
            var wallet = _repository.GetById(command.Id);

            wallet.Update();
            result.AddNotifications(wallet);

            if (result.Valid)
                _repository.Update(wallet);

            return result;
        }

        public ResultCommand Handle(DeleteWalletCommand command)
        {
            var result = new ResultCommand();

            var wallet = _repository.GetById(command.Id);

            wallet.Delete();
            result.AddNotifications(wallet);

            if (result.Valid)
                _repository.Update(wallet);
            return result;
        }
    }
}
