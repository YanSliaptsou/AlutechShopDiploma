using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public void CreateCategory(Category category)
        {
            context.Categories.Add(
                new Category
                {
                    Description = category.Description,
                    Name = category.Name
                });
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            context.Categories.Remove(context.Categories.FirstOrDefault(x => x.CategoryID == categoryId));
            context.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories.Find(category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;
                }
            }
            context.SaveChanges();
        }
    }
}