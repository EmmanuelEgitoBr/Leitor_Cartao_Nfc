using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using DigitalNfcCardReader.Domain.Fixed;
using Firebase.Database;
using Firebase.Database.Query;

namespace DigitalNfcCardReader.Infra.Data.Firebase.Repositories.v1
{
    public class NfcCardRepository : INfcCardRepository
    {
        private readonly FirebaseClient _firebaseClient;

        public NfcCardRepository()
        {
            _firebaseClient = new FirebaseClient("https://reactapp-8016d.firebaseio.com");
        }

        public async Task CreateNfcDataAsync(NfcData card)
        {
            await _firebaseClient
            .Child("NfcCards")
            .PostAsync(card);
        }

        public async Task DisableNfcDataAsync(NfcData card)
        {
            card.NfcStatus = NfcStatusType.Inactive;

            await _firebaseClient
            .Child("NfcCards")
            .Child(card.TagId.ToString())
            .PutAsync(card);
        }

        public async Task<NfcData> GetNfcDataBySerialCodeAsync(string serialCode)
        {
            var cards = await _firebaseClient
            .Child("NfcCards")
            .OnceAsync<NfcData>();

            return cards.FirstOrDefault(p => p.Object.CardSerialCode == serialCode)?.Object!;
        }

        public async Task<NfcData> GetNfcDataByTagIdAsync(long tagId)
        {
            var cards = await _firebaseClient
            .Child("NfcCards")
            .OnceAsync<NfcData>();

            return cards.FirstOrDefault(p => p.Object.TagId == tagId)?.Object!;
        }

        public async Task UpdateNfcDataAsync(NfcData card)
        {
            await _firebaseClient
            .Child("NfcCards")
            .Child(card.TagId.ToString())
            .PutAsync(card);
        }
    }
}
