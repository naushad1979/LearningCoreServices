using Catalog.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public interface IQueryService
    {
        Task<IList<Category>> GetCategoriesAsync();
        Task<IList<SubCategory>> GetSubCategoriesAsync();
        Task<IList<CategoryItem>> GetCategoryItemsAsync();
    }
}
