using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using DigitalNfcCardReader.Infra.Data.MongoDb.Configuration.v1;
using MongoDB.Driver;

namespace DigitalNfcCardReader.Infra.Data.MongoDb.Repositories.v1
{
    public class NfcCardMongoRepository : INfcCardRepository
    {
        protected readonly IMongoCollection<NfcData> _collection;
        protected readonly IMongoDatabase _database;

        public NfcCardMongoRepository(MongoSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.Database);

            _database = database;
            _collection = database.GetCollection<NfcData>(typeof(NfcData).Name);
        }

        public async Task CreateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(card, cancellationToken: cancellationToken);
        }

        public async Task<NfcData> GetNfcDataBySerialCodeAsync(string serialCode, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(d => d.CardSerialCode == serialCode).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<NfcData> GetNfcDataByTagIdAsync(long tagId, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(d => d.TagId == tagId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateNfcDataAsync(NfcData card, CancellationToken cancellationToken = default)
        {
            var filter = Builders<NfcData>.Filter.Eq("TagId", card.TagId);
            await _collection!.ReplaceOneAsync(filter, card, cancellationToken: cancellationToken);
        }
    }
}
