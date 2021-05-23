using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFDiscountRepository : IDiscountRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Discount> Discounts
        {
            get { return context.Discounts; }
        }

        public void CreateDiscount(Discount discount)
        {
            context.Discounts.Add(new Discount
            {
                GoodID = discount.GoodID,
                DiscountAmmount = discount.DiscountAmmount
            });
            context.SaveChanges();
        }

        public void DeleteDiscount(int discountId)
        {
            context.Discounts.Remove(context.Discounts.Find(discountId));
            context.SaveChanges();
        }

        public void EditDiscont(Discount discount)
        {
            Discount disc = context.Discounts.Find(discount.DiscountID);
            disc.DiscountAmmount = discount.DiscountAmmount;
            context.SaveChanges();
        }
    }
}