using Account.Api.Infrastructure;
using Account.Api.Models;
using System.Threading.Tasks;

namespace Account.Api.Database.Repositories
{
    public class AccountRepository: Repository, IAccountRepository
    {
        public AccountRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public async Task<int> RegisterAsync(UserRegistration registration)
        {
            return await SaveAsync(registration);
        }
    }
}
