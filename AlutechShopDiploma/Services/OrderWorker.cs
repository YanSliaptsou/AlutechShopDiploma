using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Web;
using AlutechShopDiploma.Models.Enums;

namespace AlutechShopDiploma.Services
{
    public class OrderWorker
    {
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        public int DefineOrderID()
        {
            int orderId = 0;

            UsersWorker worker = new UsersWorker(HttpContext.Current.User.Identity.Name);
            string userId = worker.GetUserID();

            string ordId = sqlWorker.SelectDataFromDB("SELECT OrderID FROM Orders where UserID = '" + userId + "' and isFinished = 'False'");
            if (ordId != "")
            {
                orderId = Convert.ToInt32(ordId);
            }

            return orderId;
        }

        public bool IsNecessaryToCreateANewOrder()
        {
            UsersWorker worker = new UsersWorker(HttpContext.Current.User.Identity.Name);
            string userId = worker.GetUserID();
            string ordId = sqlWorker.SelectDataFromDB("SELECT OrderID FROM Orders where UserID = '" + userId + "' and isFinished = 'False'");
            if (ordId == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double CountOrderPrice()
        {
            int orderID = DefineOrderID();
            double totalPrice = 0;

            List<string> orderItemsIDs = sqlWorker.SelectDataFromDBMult("SELECT OrderItemID FROM OrderItems WHERE OrderID = " + orderID);

            foreach(var element in orderItemsIDs)
            {
                int goodID = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT GoodID FROM OrderItems WHERE OrderItemID = " + element));

                GoodWorker goodWorker = new GoodWorker(goodID);
                double goodPrice = goodWorker.CalculateGoodPrice();

                int ammount = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT Ammount FROM OrderItems WHERE OrderItemID = " + element));

                totalPrice += goodPrice * ammount;
            }
            return totalPrice;
        }

        public double CountOrderItemPrice(int orderItemID)
        {
            int goodID = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT GoodID FROM OrderItems WHERE OrderItemID = " + orderItemID));
            
            GoodWorker goodWorker = new GoodWorker(goodID);
            double goodPrice = goodWorker.CalculateGoodPrice();

            int ammount = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT Ammount FROM OrderItems WHERE GoodID = " + goodID));

            return goodPrice * ammount;
        }

        public int DefineOrderItemsCountInOrder()
        {
            int ordId = DefineOrderID();

            List<string> ids = sqlWorker.SelectDataFromDBMult("SELECT OrderItemID FROM OrderItems WHERE OrderId = " + ordId);

            return ids.Count;
        }

        public List<string> GetOrderDetails(OrderDetail orderDetail)
        {
            int orderID = DefineOrderID();

            OrderDetailsGetter orderDetailsGetter = new OrderDetailsGetter(orderID);

            List<string> data = new List<string>();

            switch(orderDetail)
            {
                case OrderDetail.Id:
                {
                    data = orderDetailsGetter.GetOrderItemsIds();
                    break;
                }    
                case OrderDetail.Image:
                {
                    data = orderDetailsGetter.GetOrderItemsImages();
                    break;
                }
                case OrderDetail.Name:
                {
                    data = orderDetailsGetter.GetOrderItemsNames();
                    break;
                }
                case OrderDetail.PricePerGoodItem:
                {
                    data = orderDetailsGetter.GetOrderItemsPricesPerItem();
                    break;
                }
                case OrderDetail.AmountOfItems:
                {
                    data = orderDetailsGetter.GetOrderItemsAmmountsOfItems();
                    break;
                }
                case OrderDetail.PricePerOrderItem:
                {
                    data = orderDetailsGetter.GetOrderItemsPricesPerOrderItems();
                    break;
                }
            }

            return data;
        }
    }
}