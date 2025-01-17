using DigitalNfcCardReader.Domain.Fixed;

namespace DigitalNfcCardReader.Domain.Entities.v1
{
    public class NfcData
    {
        public long TagId {  get; set; }
        public string CardSerialCode { get; set; } = string.Empty;
        public string? PatientName { get; set; }
        public DateTime CardDeliveryDate { get; set; } = DateTime.Now;
        public NfcStatusType NfcStatus { get; set; }
        public DateTime CardUpdateDate { get; set; } = DateTime.Now;
        public string? ModifierUserCode { get; set; }

    }
}
