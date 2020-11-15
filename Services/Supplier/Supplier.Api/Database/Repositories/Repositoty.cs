//using Catalog.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Api.Database.Repositories
{
    public class Repositoty : IRepositoty
    {
        private const string SUPPLIERCOLLECTION = "Suppliers";

        private DatabaseContext context;
        public Repositoty(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<int> RegisterSupplierAsync(Models.Supplier supplier)
        {
            try
            {
                var collection = context.DbContext.GetCollection<Models.Supplier> (SUPPLIERCOLLECTION);               
                await collection.InsertOneAsync(supplier);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<int> CreateSubCategoryAsync(SubCategory subCategory)
        //{
        //    try
        //    {
        //        var collection = context.DbContext.GetCollection<SubCategory>(SUBCATEGORYCOLLECTION);
        //        subCategory.CreatedDate = DateTime.Now;
        //        subCategory.Active = true;
        //        await collection.InsertOneAsync(subCategory);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<IList<Models.Supplier>> GetSuppliersAsync()
        {
            var collection = context.DbContext.GetCollection< Models.Supplier> (SUPPLIERCOLLECTION);
            var results = await collection.Find(sub => true).ToListAsync();
            return results;
        }

        //public async Task<IList<SubCategory>> GetSubCategoriesAsync()
        //{
        //    var collection = context.DbContext.GetCollection<SubCategory>(SUBCATEGORYCOLLECTION);
        //    var results = await collection.Find(sub => true).ToListAsync();
        //    return results;
        //}

        //public async Task<IList<CategoryItem>> GetCategoryItemsAsync()
        //{
        //    try
        //    {
        //        CategoryItem[] results = null;
        //        await Task.Run(() =>
        //        {
        //            results = (from cat in context.DbContext.GetCollection<Category>(CATEGORYCOLLECTION).AsQueryable()
        //                       join subcat in context.DbContext.GetCollection<SubCategory>(SUBCATEGORYCOLLECTION).AsQueryable()
        //                       on cat.CategoryId equals subcat.CategoryId
        //                       into joinedSubCategory
        //                       select new CategoryItem
        //                       {
        //                           Category = new Category
        //                           {
        //                               CategoryId = cat.CategoryId,
        //                               CategoryName = cat.CategoryName,
        //                               CategoryTitle = cat.CategoryTitle
        //                           },
        //                           SubCategories = joinedSubCategory
        //                       }).ToArray();

        //        });
        //        return results.OrderBy(cat => cat.Category.CategoryName).ToArray();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
