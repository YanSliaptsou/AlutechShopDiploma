using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class GoodsSortController : Controller
    {
        // GET: Sort
        private IGoodRepository rep;

        public GoodsSortController(IGoodRepository repository)
        {
            rep = repository;
        }
        
        public PartialViewResult Sort(string fieldsort = "id", string sorttype = "asc")
        {
            IEnumerable<Good> goods = rep.Goods;
            switch (fieldsort)
            {
                case "id":
                    {
                        if (sorttype == "asc")
                        {
                            goods = rep.Goods.OrderBy(good => good.GoodID);
                        }
                        else
                        {
                            goods = rep.Goods.OrderByDescending(good => good.GoodID);
                        }
                        break;
                    }
                case "name":
                    {
                        if (sorttype == "asc")
                        {
                            goods = rep.Goods.OrderBy(good => good.Name);
                        }
                        else
                        {
                            goods = rep.Goods.OrderByDescending(good => good.Name);
                        }
                        break;
                    }
                case "price":
                    {
                        if (sorttype == "asc")
                        {
                            goods = rep.Goods.OrderBy(good => good.Price);
                        }
                        else
                        {
                            goods = rep.Goods.OrderByDescending(good => good.Price);
                        }
                        break;
                    }
                case "views":
                    {
                        if (sorttype == "asc")
                        {
                            goods = rep.Goods.OrderBy(good => good.Views);
                        }
                        else
                        {
                            goods = rep.Goods.OrderByDescending(good => good.Views);
                        }
                        break;
                    }
                case "rating":
                    {
                        if (sorttype == "asc")
                        {
                            goods = rep.Goods.OrderBy(good => good.Rating);
                        }
                        else
                        {
                            goods = rep.Goods.OrderByDescending(good => good.Rating);
                        }
                        break;
                    }
            }
            
            return PartialView(goods.ToList());
        }
    }
}