using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFGoodRepository : IGoodRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Good> Goods
        {
            get { return context.Goods; }
        }

        public void CreateGood(Good good)
        {
            context.Goods.Add(
                new Good
                {
                    Description = good.Description,
                    Name = good.Name,
                    Price = good.Price,
                    Rating = good.Rating,
                    Views = good.Views,
                    ItemID = good.ItemID,
                    TableID = good.TableID
                });
        }

        public void DeleteGood(int goodId)
        {
            context.Goods.Remove(context.Goods.FirstOrDefault(x => x.GoodID == goodId));
            context.SaveChanges();
        }

        public void EditGood(Good good)
        {
            if (good.GoodID == 0)
            {
                context.Goods.Add(good);
            }
            else
            {
                Good dbEntry = context.Goods.Find(good.GoodID);
                if (dbEntry != null)
                {
                    dbEntry.Name = good.Name;
                    dbEntry.Price = good.Price;
                    dbEntry.Rating = good.Rating;
                    dbEntry.Views = good.Views;
                    dbEntry.ItemID = good.ItemID;
                    dbEntry.TableID = good.TableID;
                    dbEntry.Description = good.Description;
                }
            }
            context.SaveChanges();
        }
    }
}