using Catalog.Api.Services;
using Supplier.Api.Database.Repositories;
using Supplier.Api.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Supplier.Api.Services
{
    public class CommandService : ICommandService
    {
        private readonly IRepositoty repositoty;
        public CommandService(IRepositoty repositoty)
        {
            this.repositoty = repositoty;
        }
        public async Task<Result> RegisterSupplierAsync(Models.Supplier supplier)
        {
            try
            {
                supplier.DateCreated = DateTime.Now;
                supplier.Active = false;

                await repositoty.RegisterSupplierAsync(supplier);
                return new Result { ResultCode = ResultCode.Created, 
                    SuccessMessage = "Your request for registration has been initiated. Your will receive an email to active your registration"
                };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        //public async Task<Result> CreateSubCategoryAsync(SubCategory subCategory)
        //{
        //    try
        //    {
        //        subCategory.CreatedDate = DateTime.Now;
        //        subCategory.Active = true;

        //        await categoryRepositoty.CreateSubCategoryAsync(subCategory);
        //        return new Result { ResultCode = ResultCode.Created, SuccessMessage = "New SubCategory Created" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
        //    }
        //}
    }
}
