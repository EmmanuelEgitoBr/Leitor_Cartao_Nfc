using DigitalNfcCardReader.Domain.Fixed;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigitalNfcCardReader.Domain.Entities.v1
{
    public class NfcData
    {
        [BsonId]
        [BsonRepresentation(BsonType.Binary)]
        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public long TagId {  get; set; }
        public string CardSerialCode { get; set; } = string.Empty;
        public string? PatientName { get; set; }
        public DateTime CardDeliveryDate { get; set; } = DateTime.Now;
        public NfcStatusType NfcStatus { get; set; }
        public DateTime CardUpdateDate { get; set; } = DateTime.Now;
        public string? ModifierUserCode { get; set; }
    }
}
