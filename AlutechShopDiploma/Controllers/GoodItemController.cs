using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class GoodItemController : Controller
    {
        public IGoodRepository repository;
        ApplicationDbContext context = new ApplicationDbContext();

        public GoodItemController(IGoodRepository rep)
        {
            repository = rep;
        }
        public ViewResult CartItem(int goodId)
        {
            Good good = context.Goods
                .FirstOrDefault(b => b.GoodID == goodId);
            good.Views += 1;

            context.SaveChanges();
            return View(good);
        }
    }
}