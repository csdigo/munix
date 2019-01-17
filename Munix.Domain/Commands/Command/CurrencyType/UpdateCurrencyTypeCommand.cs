using System;

namespace Munix.Domain.Commands.Command.CurrencyType
{
    public class UpdateCurrencyTypeCommand : CreateCurrencyTypeCommand
    {
        public Guid Id { get; set; }
    }
}
