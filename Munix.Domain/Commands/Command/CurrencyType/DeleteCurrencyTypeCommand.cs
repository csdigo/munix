using Munix.Domain.Contracts;
using System;

namespace Munix.Domain.Commands.Command.CurrencyType
{
    public class DeleteCurrencyTypeCommand : ICommand
    {
        public DeleteCurrencyTypeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
