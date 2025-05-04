using DataAccessLayer.Contexts;
using DataAccessLayer.DataModels;

namespace DataAccessLayer.Repositories
{
    public class CosmeticRepository : GenericRepository<Cosmetic>
    {
        public CosmeticRepository(MongoContext context) : base(context, "Cosmetics")
        {
        }
    }
}