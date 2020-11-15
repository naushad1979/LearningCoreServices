using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.Api.Database.Repositories
{
    public interface IRepositoty
    {
        Task<int> RegisterSupplierAsync(Supplier.Api.Models.Supplier supplier);
        //Task<int> CreateCategoryAsync(Category category);
        //Task<int> CreateSubCategoryAsync(SubCategory subCategory);
        Task<IList<Models.Supplier>> GetSuppliersAsync();
        //Task<IList<SubCategory>> GetSubCategoriesAsync();
        //Task<IList<CategoryItem>> GetCategoryItemsAsync();
    }
}
