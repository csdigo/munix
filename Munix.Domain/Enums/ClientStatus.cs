using System.ComponentModel;

namespace Munix.Domain.Enums
{
    public enum ClientStatus
    {
        [Description("Ativo")]
        Active = 1,

        [Description("Inativo")]
        Inative,

        [Description("Deletado")]
        Delete
    }
}
