using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IDiscountRepository
    {
        IEnumerable<Discount> Discounts { get; }
        void CreateDiscount(Discount discount);
        void EditDiscont(Discount discount);
        void DeleteDiscount(int discountId);
    }
}
