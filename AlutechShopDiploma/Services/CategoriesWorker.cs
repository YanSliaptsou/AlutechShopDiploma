using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Services
{
    public class CategoriesWorker
    {
        private int categoryId;
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public CategoriesWorker(int _id)
        {
            categoryId = _id;
        }

        public int GetCountOfGoods()
        {
            int count = 0;
            List<string> tables = sqlWorker.SelectDataFromDBMult("SELECT GoodTableID FROM GoodsTables WHERE CategoryID = " + categoryId);
            foreach(var table in tables)
            {
                int tableID = Convert.ToInt32(table);
                IEnumerable<Good> goods = context.Goods.Where(x => x.TableID == tableID).ToList();
                count += goods.Count();
            }
            return count;
        }

        public int GetCountOfSubcategories()
        {
            List<string> tables = sqlWorker.SelectDataFromDBMult("SELECT GoodTableID FROM GoodsTables WHERE CategoryID = " + categoryId);
            return tables.Count();
        }
    }
}