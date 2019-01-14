using System.ComponentModel;

namespace Munix.Domain.Enums
{
    public enum ClientStatus
    {
        [Description("Ativo")]
        Active,

        [Description("Inativo")]
        Inative,

        [Description("Deletado")]
        Delete
    }
}
