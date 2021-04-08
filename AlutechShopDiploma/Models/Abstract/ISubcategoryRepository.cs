using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface ISubcategoryRepository
    {
        IEnumerable<Subcategory> Subcategories { get; }
        void EditSubcategory(Subcategory subcategory);
        void CreateSubcategory(Subcategory subcategory);
        void DeleteSubcategory(int subcategoryId);
    }
}
