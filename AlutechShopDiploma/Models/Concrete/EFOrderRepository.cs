using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void CreateOrder()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.Current.User.Identity.Name);
            context.Orders.Add(
                new Order
                {
                    DateTime = DateTime.Now,
                    IsFinished = false,
                    IsOrdered = false,
                    ShopCardSessionID = System.Web.HttpContext.Current.Session.SessionID,
                    TotalSum = 0,
                    UserID = usersWorker.GetUserID()
                });
            context.SaveChanges();
        }

        public void DeleteOrder(int orderID)
        {
            context.Orders.Remove(context.Orders.FirstOrDefault(x => x.OrderID == orderID));
            context.SaveChanges();
        }

        public void EditOrderByIsFinished(int orderID, bool isFinished)
        {
            Order order = context.Orders.Find(orderID);

            if (order != null)
            {
                order.IsFinished = isFinished;
                order.DateTime = DateTime.Now;
            }

            context.SaveChanges();
        }

        public void EditOrderByIsOrdered(int orderID, bool isOrdered)
        {
            Order order = context.Orders.Find(orderID);

            if (order != null)
            {
                order.IsOrdered = isOrdered;
                order.DateTime = DateTime.Now;
            }

            context.SaveChanges();
        }

        public void EditOrderByTotalPrice(int orderID, double totalPrice)
        {
            Order order = context.Orders.Find(orderID);

            if(order != null)
            {
                order.TotalSum = totalPrice;
            }

            context.SaveChanges();
        }
    }
}