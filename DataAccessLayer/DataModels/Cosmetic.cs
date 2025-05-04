using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.DataModels
{
    public class Cosmetic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TelegramAccountId { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? OpenedDate { get; set; }
    }
}