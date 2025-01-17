using DigitalNfcCardReader.Domain.Entities.v1;

namespace DigitalNfcCardReader.Domain.Contracts.v1
{
    public interface INfcCardRepository
    {
        Task CreateNfcDataAsync(NfcData card);
        Task<NfcData> GetNfcDataByTagIdAsync(long tagId);
        Task<NfcData> GetNfcDataBySerialCodeAsync(string serialCode);
        Task UpdateNfcDataAsync(NfcData card);
    }
}
