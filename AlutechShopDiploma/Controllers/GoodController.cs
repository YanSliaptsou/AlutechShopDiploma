using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.ViewModels;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class GoodController : Controller
    {

        public IGoodRepository repository;
        public int pageSize = 3;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public GoodController(IGoodRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, string subcategory, int page = 1)
        {
            int tblID = -1;
            if (category != null && subcategory != null)
            { 
                string tbid = sqlWorker.SelectDataFromDB("SELECT GoodTableID from GoodsTables Where CategoryID = (SELECT CategoryID FROM Categories Where Name = '" + category + "') and TableName = '"+subcategory+"'");
                tblID = Convert.ToInt32(tbid);
            }
            GoodViewModel model = new GoodViewModel
            {
                Goods = repository.Goods
                .Where(good => tblID == -1 || good.TableID == tblID)
                .OrderBy(good => good.GoodID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? repository.Goods.Count() :
                    repository.Goods.Where(good => good.GoodID == tblID).Count()
                },
                CurrentCategory = category,
                CurrentSubcategory = subcategory
            };

            return View(model);
        }
    }
}