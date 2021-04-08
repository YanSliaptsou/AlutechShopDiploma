using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFSubcategoryRepository : ISubcategoryRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Subcategory> Subcategories
        {
            get { return context.Subcategories; }
        }

        public void CreateSubcategory(Subcategory subcategory)
        {
            context.Subcategories.Add(
                new Subcategory
                {
                    Name = subcategory.Name,
                    Category = subcategory.Category
                });
        }

        public void DeleteSubcategory(int subcategoryId)
        {
            context.Subcategories.Remove(context.Subcategories.FirstOrDefault(x => x.SubcategoryID == subcategoryId));
            context.SaveChanges();
        }

        public void EditSubcategory(Subcategory subcategory)
        {
            if (subcategory.SubcategoryID == 0)
            {
                context.Subcategories.Add(subcategory);
            }
            else
            {
                Subcategory dbEntry = context.Subcategories.Find(subcategory.SubcategoryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = subcategory.Name;
                    dbEntry.Category = subcategory.Category;
                }
            }
            context.SaveChanges();
        }
    }
}