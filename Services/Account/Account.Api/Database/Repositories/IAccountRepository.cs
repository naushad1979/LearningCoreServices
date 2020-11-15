using Account.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Api.Database.Repositories
{
    public interface IAccountRepository
    {
        Task<int> RegisterAsync(UserRegistration registration);
    }
}
