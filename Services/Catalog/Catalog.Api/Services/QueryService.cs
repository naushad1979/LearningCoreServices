using Catalog.Api.Database.Repositories;
using Catalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public class QueryService : IQueryService
    {
        private readonly ICategoryRepositoty categoryRepositoty;
        public QueryService(ICategoryRepositoty categoryRepositoty)
        {
            this.categoryRepositoty = categoryRepositoty;
        }
        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await categoryRepositoty.GetCategoriesAsync();
        }
        public async Task<IList<SubCategory>> GetSubCategoriesAsync()
        {
            return await categoryRepositoty.GetSubCategoriesAsync();
        }
        public async Task<IList<CategoryItem>> GetCategoryItemsAsync()
        {
            return await categoryRepositoty.GetCategoryItemsAsync();
        }       
    }
}
