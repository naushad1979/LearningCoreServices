using Account.Api.Database.Repositories;
using Account.Api.Infrastructure;
using Account.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Api.Services
{
    public class CommandService : ICommandService
    {
        private const string key = "E546C8DF278CD5931069B522E695D4F2";
        private readonly IAccountRepository repository;
        private readonly IRSAHelper rSAHelper;
        public CommandService(IAccountRepository repository, IRSAHelper rSAHelper)
        {
            this.repository = repository;
            this.rSAHelper = rSAHelper;
        }

        public async Task<ServiceResponse> RegisterAsync(UserRegistration registration)
        {
            try
            {
                registration.DateCreated = DateTime.Now;
                registration.DateUpdated = null;
                registration.Active = false;

                //Decrypted password which is based on public and private key
                var decryptedPassword = rSAHelper.Decrypt(registration.Password);

                //For database specific secured password
                registration.Password = EncryptHelper.EncryptString(decryptedPassword, key);

                await repository.RegisterAsync(registration);
                return new ServiceResponse
                {
                    Status = true,
                    Message = string.Format("Dear {0}{1}{2}", registration.Name, " ",
                    "Your account has been created. You will receive an email to activate your account.") 
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { Status = false, Message = ex.Message };
            }
        }
    }
}
