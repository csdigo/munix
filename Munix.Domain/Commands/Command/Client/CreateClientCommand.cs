using Munix.Domain.Contracts;

namespace Munix.Domain.Commands.Command.Client
{
    public class CreateClientCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
