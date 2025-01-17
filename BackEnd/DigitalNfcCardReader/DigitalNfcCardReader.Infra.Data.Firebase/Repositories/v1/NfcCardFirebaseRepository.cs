using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using DigitalNfcCardReader.Domain.Fixed;
using Firebase.Database;
using Firebase.Database.Query;

namespace DigitalNfcCardReader.Infra.Data.Firebase.Repositories.v1
{
    public class NfcCardFirebaseRepository : INfcCardRepository
    {
        private readonly FirebaseClient _firebaseClient;

        public NfcCardFirebaseRepository()
        {
            _firebaseClient = new FirebaseClient("https://reactapp-8016d.firebaseio.com");
        }

        public async Task CreateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default)
        {
            await _firebaseClient
            .Child("NfcCards")
            .PostAsync(card);
        }

        public async Task DisableNfcDataAsync(NfcData card, CancellationToken cancellationToken = default)
        {
            card.NfcStatus = NfcStatusType.Inactive;

            await _firebaseClient
            .Child("NfcCards")
            .Child(card.TagId.ToString())
            .PutAsync(card);
        }

        public async Task<NfcData> GetNfcDataBySerialCodeAsync(string serialCode, CancellationToken cancellationToken = default)
        {
            var cards = await _firebaseClient
            .Child("NfcCards")
            .OnceAsync<NfcData>();

            return cards.FirstOrDefault(p => p.Object.CardSerialCode == serialCode)?.Object!;
        }

        public async Task<NfcData> GetNfcDataByTagIdAsync(long tagId, CancellationToken cancellationToken = default)
        {
            var cards = await _firebaseClient
            .Child("NfcCards")
            .OnceAsync<NfcData>();

            return cards.FirstOrDefault(p => p.Object.TagId == tagId)?.Object!;
        }

        public async Task UpdateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default)
        {
            await _firebaseClient
            .Child("NfcCards")
            .Child(card.TagId.ToString())
            .PutAsync(card);
        }
    }
}
