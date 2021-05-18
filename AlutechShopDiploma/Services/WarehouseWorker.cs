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

        public void SubtractGoodsAmmount()
        {
            IEnumerable<OrderItem> items = applicationDbContext.OrderItems.Where(x => x.OrderID == order.OrderID);
            
            foreach(var item in items)
            {
                int goodId = item.GoodID;
                int ammount = item.Ammount;

                int warehouseId = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT WarehouseID FROM Warehouses WHERE GoodID = " + goodId));

                Warehouse warehouse = applicationDbContext.Warehouses.Find(warehouseId);
                warehouse.GoodAmmount -= ammount;
                applicationDbContext.SaveChanges();
            }
        }
    }
}