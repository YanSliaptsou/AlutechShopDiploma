using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Services
{
    public class WarehouseWorker
    {
        private Order order;
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");


        public WarehouseWorker(Order _order)
        {
            order = _order;
        }
        public WarehouseWorker()
        {

        }

        public void SubtractGoodsAmmount()
        {
            IEnumerable<OrderItem> items = applicationDbContext.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
            //Warehouse warehouse = applicationDbContext.Warehouses.FirstOrDefault(x => x.GoodID == 3);

            foreach (var item in items)
            {
                int goodId = item.GoodID;
                int ammount = item.Ammount;

                Warehouse warehouse = applicationDbContext.Warehouses.FirstOrDefault(x => x.GoodID == item.GoodID);
                warehouse.GoodAmmount -= ammount;
                applicationDbContext.SaveChanges();


            }
        }
        public int GetProductAmmount(int goodId)
        {
            return Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT GoodAmmount from Warehouses WHERE GoodID = " + goodId));
        }

    }
}