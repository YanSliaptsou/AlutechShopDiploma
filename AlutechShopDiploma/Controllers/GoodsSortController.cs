using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models.Enums;
using AlutechShopDiploma.Models.ViewModels;
using AlutechShopDiploma.SQL;
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
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        public int pageSize = 3;

        public GoodsSortController(IGoodRepository repository)
        {
            rep = repository;
           
        }
        
        public PartialViewResult Sort(string category, string subcategory, SortState sortState = SortState.IdAsc, int page = 1)
        {
            List<string> tbid1 = new List<string>();
            int tblID = -1;
            if (category != null && subcategory != null)
            {
                string tbid = sqlWorker.SelectDataFromDB("SELECT GoodTableID from GoodsTables Where CategoryID = (SELECT CategoryID FROM Categories Where Description = '" + category + "') and TableName = '" + subcategory + "'");
                if (tbid != null)
                {
                    tblID = Convert.ToInt32(tbid);
                }
            }
            else if (subcategory == null)
            {
                {
                    tbid1 = sqlWorker.SelectDataFromDBMult("SELECT GoodTableID from GoodsTables Where CategoryID = (SELECT CategoryID FROM Categories Where Name = '" + category + "') ");
                }
            }

            IEnumerable<Good> goods = rep.Goods;

            switch (sortState)
            {
                case SortState.IdAsc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderBy(good => good.GoodID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.NameAsc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderBy(good => good.Name)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.NameDesc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderByDescending(good => good.Name)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.PriceAsc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderBy(good => good.Price)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.PriceDesc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderByDescending(good => good.Price)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.RatingAsc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderBy(good => good.Rating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.RatingDesc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderByDescending(good => good.Rating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.ViewsAsc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderBy(good => good.Views)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
                case SortState.ViewsDesc:
                    {
                        goods = rep.Goods
                        .Where(good => tblID == -1 || good.TableID == tblID || tbid1.Contains(Convert.ToString(good.TableID)))
                        .OrderByDescending(good => good.Views)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                        break;
                    }
            }

            int c = goods.Count();
            GoodViewModel model = new GoodViewModel
            {
                Goods = goods,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = rep.Goods.Count()
                },
                CurrentCategory = category,
                CurrentSubcategory = subcategory,
                SortState = sortState
            };

            return PartialView(model);
        }
    }
}