using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Services
{
    public class OrderDetailsGetter
    {
        private int orderId;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public OrderDetailsGetter(int _orderId)
        {
            this.orderId = _orderId;
        }

        public List<string> GetOrderItemsIds()
        {
            return sqlWorker.SelectDataFromDBMult("SELECT OrderItemID FROM OrderItems WHERE OrderId = " + orderId);
        }

        public List<string> GetOrderItemsImages()
        {
            List<string> goodIds = sqlWorker.SelectDataFromDBMult("SELECT GoodID FROM OrderItems WHERE OrderId = " + orderId);
            List<string> urls = new List<string>();

            foreach(var id in goodIds)
            {
                urls.Add(sqlWorker.SelectDataFromDB("SELECT Url from ImageContainers WHERE GoodId = " + id));
            }

            return urls;
        }

        public List<string> GetOrderItemsNames()
        {
            List<string> goodIds = sqlWorker.SelectDataFromDBMult("SELECT GoodID FROM OrderItems WHERE OrderId = " + orderId);
            List<string> names = new List<string>();

            foreach (var id in goodIds)
            {
                names.Add(sqlWorker.SelectDataFromDB("SELECT Name from Goods WHERE GoodId = " + id));
            }

            return names;
        }
        public List<string> GetOrderItemsPricesPerItem()
        {
            List<string> goodIds = sqlWorker.SelectDataFromDBMult("SELECT GoodID FROM OrderItems WHERE OrderId = " + orderId);
            List<string> pricePerItem = new List<string>();

            foreach(var id in goodIds)
            {
                GoodWorker goodWorker = new GoodWorker(Convert.ToInt32(id));
                pricePerItem.Add(Convert.ToString(goodWorker.CalculateGoodPrice()));
            }

            return pricePerItem;
        }

        public List<string> GetOrderItemsAmmountsOfItems()
        {
            List<string> ammountOfItems = sqlWorker.SelectDataFromDBMult("SELECT Ammount FROM OrderItems WHERE OrderId = " + orderId);

            return ammountOfItems;
        }

        public List<string> GetOrderItemsPricesPerOrderItems()
        {
            List<string> orderItemsIDs = sqlWorker.SelectDataFromDBMult("SELECT OrderItemID FROM OrderItems WHERE OrderId = " + orderId);
            List<string> pricesPerOrderItem = new List<string>();
            OrderWorker orderWorker = new OrderWorker();

            foreach(var orderItemID in orderItemsIDs)
            { 
                pricesPerOrderItem.Add(Convert.ToString(orderWorker.CountOrderItemPrice(Convert.ToInt32(orderItemID))));
            }

            return pricesPerOrderItem;
        }
    }
}