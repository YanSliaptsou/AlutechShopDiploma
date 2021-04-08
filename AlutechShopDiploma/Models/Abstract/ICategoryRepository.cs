using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;}
        void CreateCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
