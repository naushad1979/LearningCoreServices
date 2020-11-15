using Catalog.Api.Database.Repositories;
using Catalog.Api.Infrastructure;
using Catalog.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICategoryRepositoty repositoty;
        public CommandService(ICategoryRepositoty categoryRepositoty)
        {
            this.repositoty = categoryRepositoty;
        }
        public async Task<Result> CreateCategoryAsync(Category category)
        {
            try
            {
                category.CreatedDate = DateTime.Now;
                category.Active = true;

                await repositoty.CreateCategoryAsync(category);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "New Category Created" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        public async Task<Result> CreateManyCategoryAsync(IEnumerable<Category> categories)
        {
            try
            {
                foreach (var category in categories)
                {
                    category.CreatedDate = DateTime.Now;
                    category.Active = true;
                }
                await repositoty.CreateManyCategoryAsync(categories);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "Categories Created" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        public async Task<Result> CreateSubCategoryAsync(SubCategory subCategory)
        {
            try
            {
                subCategory.CreatedDate = DateTime.Now;
                subCategory.Active = true;

                await repositoty.CreateSubCategoryAsync(subCategory);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "New SubCategory Created" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        public async Task<Result> CreateManySubCategoryAsync(IEnumerable<SubCategory> subCategories)
        {
            try
            {
                foreach (var subCategory in subCategories)
                {
                    subCategory.CreatedDate = DateTime.Now;
                    subCategory.Active = true;
                }
                await repositoty.CreateManySubCategoryAsync(subCategories);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "SubCategories Created" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }
        public async Task<Result> DeleteCategoryAsync(Category category)
        {
            try
            {
                await repositoty.DeleteCategoryAsync(category);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "Category Deleted" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }
        public async Task<Result> DeleteSubCategoryAsync(SubCategory DeleteSubCategoryAsync)
        {
            try
            {
                await repositoty.DeleteSubCategoryAsync(DeleteSubCategoryAsync);
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "SubCategory Deleted" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        public async Task<Result> DeleteAllCategoryAsync()
        {
            try
            {
                await repositoty.DeleteAllCategoryAsync();
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "All Category Deleted" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }

        public async Task<Result> DeleteAllSubCategoryAsync()
        {
            try
            {
                await repositoty.DeleteAllSubCategoryAsync();
                return new Result { ResultCode = ResultCode.Created, SuccessMessage = "All SubCategory Deleted" };
            }
            catch (Exception ex)
            {
                return new Result { ResultCode = ResultCode.Exception, ErrorMessage = ex.Message };
            }
        }
    }
}
