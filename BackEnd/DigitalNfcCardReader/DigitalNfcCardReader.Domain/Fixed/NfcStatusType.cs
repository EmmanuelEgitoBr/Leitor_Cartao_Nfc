using System.ComponentModel;

namespace DigitalNfcCardReader.Domain.Fixed
{
    public enum NfcStatusType
    {
        [Description("Ativo")]
        Active,

        [Description("Inativo")]
        Inactive,

        [Description("Bloqueado")]
        Blocked
    }
}
