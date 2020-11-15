using Catalog.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Database.Repositories
{
    public interface ICategoryRepositoty
    {
        Task<int> CreateCategoryAsync(Category category);
        Task<int> CreateManyCategoryAsync(IEnumerable<Category> categories);
        Task<int> DeleteCategoryAsync(Category category);
        Task<int> DeleteAllCategoryAsync();
        Task<int> CreateSubCategoryAsync(SubCategory subCategory);
        Task<int> CreateManySubCategoryAsync(IEnumerable<SubCategory> subCategories);
        Task<int> DeleteSubCategoryAsync(SubCategory subCategory);
        Task<int> DeleteAllSubCategoryAsync();
        Task<IList<Category>> GetCategoriesAsync();
        Task<IList<SubCategory>> GetSubCategoriesAsync();
        Task<IList<CategoryItem>> GetCategoryItemsAsync();       
    }
}
