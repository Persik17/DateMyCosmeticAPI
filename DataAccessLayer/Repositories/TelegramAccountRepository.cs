using DataAccessLayer.Contexts;
using DataAccessLayer.DataModels;

namespace DataAccessLayer.Repositories
{
    public class TelegramAccountRepository : GenericRepository<TelegramAccount>
    {
        public TelegramAccountRepository(MongoContext context) : base(context, "TelegramAccounts")
        {
        }
    }
}