using Munix.Domain.Commands.Command.CurrencyType;
using Munix.Domain.Commands.Result;
using Munix.Domain.Contracts;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Entities;

namespace Munix.Domain.Commands.CommandHandler
{
    public class CurrencyTypeCommandHandler :
        ICommandHandler<CreateCurrencyTypeCommand, ResultCommand>,
        ICommandHandler<UpdateCurrencyTypeCommand, ResultCommand>,
        ICommandHandler<DeleteCurrencyTypeCommand, ResultCommand>
    {

        ICurrencyTypeRepository _repository;

        public CurrencyTypeCommandHandler(ICurrencyTypeRepository repository)
        {
            _repository = repository;
        }

        public ResultCommand Handle(DeleteCurrencyTypeCommand command)
        {
            var result = new ResultCommand();

            var currencyType = _repository.GetById(command.Id);

            currencyType.Delete();

            result.AddNotifications(currencyType);

            if (result.Valid)
                _repository.Update(currencyType);

            return result;

        }

        public ResultCommand Handle(UpdateCurrencyTypeCommand command)
        {
            var result = new ResultCommand();

            var currencyType = _repository.GetById(command.Id);

            currencyType.Update(command.Name, command.Initials, command.Current, command.CultureInfo);

            result.AddNotifications(currencyType);

            if (result.Valid)
                _repository.Update(currencyType);

            return result;
        }

        public ResultCommand Handle(CreateCurrencyTypeCommand command)
        {
            var result = new ResultCommand();

            var currencyType = new CurrencyType(command.Name, command.Initials, command.Current, command.CultureInfo);

            result.AddNotifications(currencyType);

            if (result.Valid)
                _repository.Insert(currencyType);

            return result;
        }
    }
}
