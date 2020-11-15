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
        public CommandService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> RegisterAsync(UserRegistration registration)
        {
            try
            {
                registration.DateCreated = DateTime.Now;
                registration.DateUpdated = null;
                registration.Active = false;

                registration.Password = EncryptHelper.EncryptString(registration.Password, key);

                await repository.RegisterAsync(registration);
                return new Result 
                { 
                    ResultCode = ResultCode.Created, 
                    SuccessMessage = "Your account has been created. You will receive an email to activate the account." 
                };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }
    }
}
