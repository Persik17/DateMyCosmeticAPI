using Microsoft.Extensions.Options;
using MongoDB.Driver;
using DataAccessLayer.DataModels;
using DataAccessLayer.Configuration;

namespace DataAccessLayer.Contexts
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<IMongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Cosmetic> Cosmetics => _database.GetCollection<Cosmetic>("Cosmetics");
        public IMongoCollection<TelegramAccount> TelegramAccounts => _database.GetCollection<TelegramAccount>("TelegramAccounts");
    }
}