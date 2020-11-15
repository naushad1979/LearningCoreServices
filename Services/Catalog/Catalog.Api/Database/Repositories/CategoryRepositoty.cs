using Catalog.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Database.Repositories
{
    public class CategoryRepositoty : ICategoryRepositoty
    {
        private DatabaseContext context;
        public CategoryRepositoty(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            try
            {
                category.CreatedDate = DateTime.Now;
                category.Active = true;
                await CategoryCollection.InsertOneAsync(category);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateSubCategoryAsync(SubCategory subCategory)
        {
            try
            {
                subCategory.CreatedDate = DateTime.Now;
                subCategory.Active = true;
                await SubCategoryCollection.InsertOneAsync(subCategory);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var results = await CategoryCollection.Find(sub => true).ToListAsync();
            return results;
        }

        public async Task<IList<SubCategory>> GetSubCategoriesAsync()
        {
            var results = await SubCategoryCollection.Find(sub => true).ToListAsync();
            return results;
        }

        public async Task<IList<CategoryItem>> GetCategoryItemsAsync()
        {
            try
            {
                CategoryItem[] results = null;
                await Task.Run(() =>
                {
                    results = (from cat in CategoryCollection.AsQueryable()
                               join subcat in SubCategoryCollection.AsQueryable()
                               on cat.CategoryId equals subcat.CategoryId
                               into joinedSubCategory
                               select new CategoryItem
                               {
                                   Category = new Category
                                   {
                                       CategoryId = cat.CategoryId,
                                       CategoryName = cat.CategoryName,
                                       CategoryTitle = cat.CategoryTitle,
                                       IconName = cat.IconName
                                   },
                                   SubCategories = joinedSubCategory
                               }).ToArray();

                });
                return results.OrderBy(cat => cat.Category.CategoryName).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            try
            {
                await CategoryCollection.DeleteOneAsync(c => c.CategoryId == category.CategoryId);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public async Task<int> DeleteAllCategoryAsync()
        {
            try
            {
                await CategoryCollection.DeleteManyAsync(sub => true);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteSubCategoryAsync(SubCategory subCategory)
        {
            try
            {
                await SubCategoryCollection.DeleteOneAsync(s => s.SubCategoryId == subCategory.SubCategoryId);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateManyCategoryAsync(IEnumerable<Category> categories)
        {
            try
            {                              
                await CategoryCollection.InsertManyAsync(categories);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateManySubCategoryAsync(IEnumerable<SubCategory> subCategories)
        {
            try
            {
                await SubCategoryCollection.InsertManyAsync(subCategories);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAllSubCategoryAsync()
        {
            try
            {
                await SubCategoryCollection.DeleteManyAsync(sub => true);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IMongoCollection<Category> CategoryCollection
        {
            get
            {
                return context.DbContext.GetCollection<Category>("Categories");
            }
        }
        private IMongoCollection<SubCategory> SubCategoryCollection
        {
            get
            {
                return context.DbContext.GetCollection<SubCategory>("SubCategories");
            }
        }
    }
}
