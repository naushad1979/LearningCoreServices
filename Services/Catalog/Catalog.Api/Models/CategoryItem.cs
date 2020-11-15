using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Models
{
    public class CategoryItem
    {
        public CategoryItem()
        {
            Category = new Category();
            SubCategories = new List<SubCategory>();
        }
        public Category Category { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
