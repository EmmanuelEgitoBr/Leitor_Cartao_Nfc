using DigitalNfcCardReader.Domain.Fixed;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Create
{
    public sealed class CreateNfcCardCommand : IRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public long TagId { get; set; }
        public string CardSerialCode { get; set; } = string.Empty;
        public string? PatientName { get; set; }
        public DateTime CardDeliveryDate { get; set; } = DateTime.Now;
        public NfcStatusType NfcStatus { get; set; }
        public DateTime CardUpdateDate { get; set; } = DateTime.Now;
        public string? ModifierUserCode { get; set; }
    }
}
