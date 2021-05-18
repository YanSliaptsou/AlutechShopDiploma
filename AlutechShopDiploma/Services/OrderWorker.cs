using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Web;
using AlutechShopDiploma.Models.Enums;
using System.Web.Mvc;

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

        public double GetOrderPrice()
        {
            return Convert.ToDouble(sqlWorker.SelectDataFromDB("SELECT TotalSum FROM Orders WHERE OrderID = " + DefineOrderID()));
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

        public double GetBonusPercentage()
        {
            double totalPrice = GetOrderPrice();

            double percentage = 0;

            if(totalPrice < 1000)
            {
                percentage = 0.5;
            }
            else if(totalPrice >= 1000 && totalPrice < 2500)
            {
                percentage = 1;
            }
            else if (totalPrice >= 2500 && totalPrice < 5000)
            {
                percentage = 1.5;
            }
            else if (totalPrice >= 5000 && totalPrice < 7500)
            {
                percentage = 2;
            }
            else if (totalPrice >= 7500 && totalPrice < 10000)
            {
                percentage = 2.5;
            }
            else if (totalPrice >= 10000 && totalPrice < 12500)
            {
                percentage = 3;
            }
            else if (totalPrice >= 12500 && totalPrice < 15000)
            {
                percentage = 3.5;
            }
            else if (totalPrice >= 15000 && totalPrice < 17500)
            {
                percentage = 4;
            }
            else if (totalPrice >= 17500 && totalPrice < 20000)
            {
                percentage = 4.5;
            }
            else if (totalPrice >= 20000 && totalPrice < 25000)
            {
                percentage = 5;
            }
            else if (totalPrice >= 25000 && totalPrice < 30000)
            {
                percentage = 5.5;
            }
            else if (totalPrice >= 30000 && totalPrice < 35000)
            {
                percentage = 6;
            }
            else if (totalPrice >= 35000 && totalPrice < 40000)
            {
                percentage = 6.5;
            }
            else if (totalPrice >= 40000 && totalPrice < 45000)
            {
                percentage = 7;
            }
            else if (totalPrice >= 45000 && totalPrice < 50000)
            {
                percentage = 7.5;
            }
            else if (totalPrice >= 50000 && totalPrice < 75000)
            {
                percentage = 8;
            }
            else if (totalPrice >= 75000 && totalPrice < 100000)
            {
                percentage = 9;
            }
            else if(totalPrice >= 100000)
            {
                percentage = 10;
            }

            return percentage;
        }

        public double GetBonusPercentage(Order order)
        {
            double percentage = 0;

            if (order.TotalSum < 1000)
            {
                percentage = 0.5;
            }
            else if (order.TotalSum >= 1000 && order.TotalSum < 2500)
            {
                percentage = 1;
            }
            else if (order.TotalSum >= 2500 && order.TotalSum < 5000)
            {
                percentage = 1.5;
            }
            else if (order.TotalSum >= 5000 && order.TotalSum < 7500)
            {
                percentage = 2;
            }
            else if (order.TotalSum >= 7500 && order.TotalSum < 10000)
            {
                percentage = 2.5;
            }
            else if (order.TotalSum >= 10000 && order.TotalSum < 12500)
            {
                percentage = 3;
            }
            else if (order.TotalSum >= 12500 && order.TotalSum < 15000)
            {
                percentage = 3.5;
            }
            else if (order.TotalSum >= 15000 && order.TotalSum < 17500)
            {
                percentage = 4;
            }
            else if (order.TotalSum >= 17500 && order.TotalSum < 20000)
            {
                percentage = 4.5;
            }
            else if (order.TotalSum >= 20000 && order.TotalSum < 25000)
            {
                percentage = 5;
            }
            else if (order.TotalSum >= 25000 && order.TotalSum < 30000)
            {
                percentage = 5.5;
            }
            else if (order.TotalSum >= 30000 && order.TotalSum < 35000)
            {
                percentage = 6;
            }
            else if (order.TotalSum >= 35000 && order.TotalSum < 40000)
            {
                percentage = 6.5;
            }
            else if (order.TotalSum >= 40000 && order.TotalSum < 45000)
            {
                percentage = 7;
            }
            else if (order.TotalSum >= 45000 && order.TotalSum < 50000)
            {
                percentage = 7.5;
            }
            else if (order.TotalSum >= 50000 && order.TotalSum < 75000)
            {
                percentage = 8;
            }
            else if (order.TotalSum >= 75000 && order.TotalSum < 100000)
            {
                percentage = 9;
            }
            else if (order.TotalSum >= 100000)
            {
                percentage = 10;
            }

            return percentage;
        }

        public double CountUserBonus(Order order)
        {
            return Math.Round(order.TotalSum * GetBonusPercentage(order) / 100, 2);
        }
    }
}