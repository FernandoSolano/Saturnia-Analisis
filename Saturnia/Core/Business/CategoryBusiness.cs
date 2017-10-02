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

        public void DeleteCategory(Category category)
        {
            this.categoryData.DeleteCategory(category);
        }

        public Category GetCategory(int idCategory)
        {
            return this.categoryData.GetCategory(idCategory);
        }

    }
}
