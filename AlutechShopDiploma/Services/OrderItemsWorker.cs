using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Services
{
    public class OrderItemsWorker
    {
        private int goodID;
        private OrderItem item;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        ApplicationDbContext context = new ApplicationDbContext();

        public OrderItemsWorker(int usersGoodID, OrderItem userItem)
        {
            this.goodID = usersGoodID;
            this.item = userItem;
        }

        public int GetRestGoods()
        {
            string warehouseGoodAmmount = sqlWorker.SelectDataFromDB("SELECT GoodAmmount from Warehouses WHERE GoodID = " + goodID);

            int restGoods;

            if(warehouseGoodAmmount != "")
            {
                int res = Convert.ToInt32(warehouseGoodAmmount) - item.Ammount;

                if(res >= 0)
                {
                    restGoods = 0;
                }
                else
                {
                    restGoods = Math.Abs(res);
                }
            }
            else
            {
                restGoods = item.Ammount;
            }

            return restGoods;
        }

        public bool IsCompletedItem()
        {
            int restGoods = GetRestGoods();
            
            if(restGoods > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DefineIfLineExists()
        {
            OrderWorker worker = new OrderWorker();
            int currentOrderId = worker.DefineOrderID();

            string orderlineId = sqlWorker.SelectDataFromDB("SELECT OrderItemID FROM OrderItems Where OrderID = " + currentOrderId + " And GoodID = " + goodID);
            
            if(orderlineId == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(orderlineId);
            }

        }
    }
}