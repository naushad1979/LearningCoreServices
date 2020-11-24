using Account.Api.Infrastructure;
using Account.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Api.Services
{
    public interface ICommandService
    {
        Task<ServiceResponse> RegisterAsync(UserRegistration registration);    
    }
}
