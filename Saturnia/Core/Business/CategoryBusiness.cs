using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class CategoryBusiness
    {
        private CategoryData categoryData;

        public CategoryBusiness()
        {
            categoryData = new CategoryData();
        }

        public Category AddCategory(Category category)
        {
            return categoryData.AddCategory(category);
        }

        public List<Category> SearchCategory(Category category)
        {
            List<Category> categories;

            categories = this.categoryData.SearchCategory(category);

            return categories;
        }

        public Category ShowCategory(Category category)
        {
            category = this.categoryData.ShowCategory(category);

            return category;
        }
      
        public void DeleteCategory(Category category)
        {
            this.categoryData.DeleteCategory(category);
        }
    }
}
