using MongoDB.Driver;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(MongoContext context, string collectionName)
        {
            _collection = context.GetType().GetProperty(collectionName).GetValue(context, null) as IMongoCollection<T>;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.GetType().GetProperty("Id").GetValue(x, null).ToString() == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(x => x.GetType().GetProperty("Id").GetValue(x, null).ToString() == id, entity);
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.GetType().GetProperty("Id").GetValue(x, null).ToString() == id);
        }
    }
}