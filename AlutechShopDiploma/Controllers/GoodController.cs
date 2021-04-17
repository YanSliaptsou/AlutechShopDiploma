using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models.Enums;
using AlutechShopDiploma.Models.ViewModels;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                CurrentSubcategory = subcategory,
                SortState = SortState.IdAsc
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Sort(string category, string subcategory,SortState sortState = SortState.IdAsc, int page = 1)
        {
            int tblID = -1;
            if (category != null && subcategory != null)
            {
                string tbid = sqlWorker.SelectDataFromDB("SELECT GoodTableID from GoodsTables Where CategoryID = (SELECT CategoryID FROM Categories Where Name = '" + category + "') and TableName = '" + subcategory + "'");
                if (tbid != null)
                {
                    tblID = Convert.ToInt32(tbid);
                }
            }

            IEnumerable<Good> goods = repository.Goods;

            switch (sortState)
            {
                case SortState.IdAsc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderBy(good => good.GoodID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.NameAsc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderBy(good => good.Name)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.NameDesc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderByDescending(good => good.Name)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.PriceAsc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderBy(good => good.Price)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.PriceDesc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderByDescending(good => good.Price)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.RatingAsc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderBy(good => good.Rating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.RatingDesc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderByDescending(good => good.Rating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.ViewsAsc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderBy(good => good.Views)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.ViewsDesc:
                    {
                        goods = repository.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID)
                        .OrderByDescending(good => good.Views)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
            }


            GoodViewModel model = new GoodViewModel
            {
                Goods = goods,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems =  repository.Goods.Count()
                },
                CurrentCategory = category,
                CurrentSubcategory = subcategory,
                SortState = sortState
            };

            return View(model);
        }

        /*public async Task<ActionResult> Sort(SortState sortState = SortState.IdAsc)
        {
            IEnumerable<Good> goods = repository.Goods;

            switch(sortState)
            {
                case SortState.IdAsc:
                    {
                        goods.OrderBy(good => good.GoodID);
                        break;
                    }
                case SortState.NameAsc:
                    {
                        goods.OrderBy(good => good.Name);
                        break;
                    }
                case SortState.NameDesc:
                    {
                        goods.OrderByDescending(good => good.Name);
                        break;
                    }
                case SortState.PriceAsc:
                    {
                        goods.OrderBy(good => good.Price);
                        break;
                    }
                case SortState.PriceDesc:
                    {
                        goods.OrderByDescending(good => good.Price);
                        break;
                    }
                case SortState.RatingAsc:
                    {
                        goods.OrderBy(good => good.Rating);
                        break;
                    }
                case SortState.RatingDesc:
                    {
                        goods.OrderByDescending(good => good.Rating);
                        break;
                    }
                case SortState.ViewsAsc:
                    {
                        goods.OrderBy(good => good.Views);
                        break;
                    }
                case SortState.ViewsDesc:
                    {
                        goods.OrderByDescending(good => good.Views);
                        break;
                    }
            }
            return View(goods.ToList());
        }*/
    }
}