using DigitalNfcCardReader.Domain.Entities.v1;

namespace DigitalNfcCardReader.Domain.Contracts.v1
{
    public interface INfcCardRepository
    {
        Task CreateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default);
        Task<NfcData> GetNfcDataByTagIdAsync(long tagId, CancellationToken cancellationToken = default);
        Task<NfcData> GetNfcDataBySerialCodeAsync(string serialCode, CancellationToken cancellationToken = default);
        Task UpdateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default);
    }
}
