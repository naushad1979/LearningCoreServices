using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Api.Services
{
    public interface IQueryService
    {
        Task<IList<Models.Supplier>> GetSuppliersAsync();
        // Task<IList<SubCategory>> GetSubCategoriesAsync();
        //Task<IList<CategoryItem>> GetCategoryItemsAsync();
    }
}
