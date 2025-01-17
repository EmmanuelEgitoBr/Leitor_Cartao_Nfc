using DigitalNfcCardReader.Domain.Fixed;
using MediatR;

namespace DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Update
{
    public sealed class UpdateNfcCardCommand : IRequest
    {
        public Guid Id { get; set; }
        public long TagId { get; set; }
        public string CardSerialCode { get; set; } = string.Empty;
        public string? PatientName { get; set; }
        public DateTime CardDeliveryDate { get; set; } = DateTime.Now;
        public NfcStatusType NfcStatus { get; set; }
        public DateTime CardUpdateDate { get; set; } = DateTime.Now;
        public string? ModifierUserCode { get; set; }
    }
}
