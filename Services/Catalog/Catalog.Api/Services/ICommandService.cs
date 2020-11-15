using Catalog.Api.Infrastructure;
using Catalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public interface ICommandService
    {
        Task<Result> CreateCategoryAsync(Category category);
        Task<Result> CreateManyCategoryAsync(IEnumerable<Category> categories);
        Task<Result> CreateSubCategoryAsync(SubCategory subCategory);
        Task<Result> CreateManySubCategoryAsync(IEnumerable<SubCategory> subCategories);
        Task<Result> DeleteCategoryAsync(Category category);
        Task<Result> DeleteSubCategoryAsync(SubCategory subCategory);
        Task<Result> DeleteAllCategoryAsync();
        Task<Result> DeleteAllSubCategoryAsync();
    }
}
