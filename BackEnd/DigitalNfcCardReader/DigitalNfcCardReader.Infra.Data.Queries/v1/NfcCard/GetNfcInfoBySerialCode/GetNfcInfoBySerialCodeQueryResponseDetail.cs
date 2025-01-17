using DigitalNfcCardReader.Domain.Fixed;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode
{
    public sealed record GetNfcInfoBySerialCodeQueryResponseDetail
    {
        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public long TagId { get; set; }
        public string CardSerialCode { get; set; } = string.Empty;
        public string? PatientName { get; set; }
        public DateTime CardDeliveryDate { get; set; } = DateTime.Now;
        public NfcStatusType NfcStatus { get; set; }
        public DateTime CardUpdateDate { get; set; } = DateTime.Now;
        public string? ModifierUserCode { get; set; }
    }
}
