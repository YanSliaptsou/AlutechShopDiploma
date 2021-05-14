using AlutechShopDiploma.Controllers;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using AlutechShopDiploma.Services;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFOrderItemRepository : IOrderItemRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        IOrderRepository _repo;


        public EFOrderItemRepository(IOrderRepository repository)
        {
            _repo = repository;
        }

        public IEnumerable<OrderItem> OrderItems
        {
            get { return context.OrderItems; }
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            OrderItemsWorker worker = new OrderItemsWorker(GoodItemController.goodID, orderItem);
            OrderWorker orderWorker = new OrderWorker();
            if(orderWorker.IsNecessaryToCreateANewOrder())
            {
                _repo.CreateOrder();
            }
            int currentOrderId = orderWorker.DefineOrderID();
            if (worker.DefineIfLineExists() == 0)
            {
                context.OrderItems.Add(
                    new OrderItem
                    {
                        GoodID = GoodItemController.goodID,
                        Ammount = orderItem.Ammount,
                        ShopCardSessionID = System.Web.HttpContext.Current.Session.SessionID,
                        RestGoods = worker.GetRestGoods(),
                        IsCompletedItem = worker.IsCompletedItem(),
                        OrderID = currentOrderId
                    });
                context.SaveChanges();
            }
            else
            {
                OrderItem item = context.OrderItems.Find(worker.DefineIfLineExists());
                if(item != null)
                {
                    item.Ammount += orderItem.Ammount;
                }
                context.SaveChanges();
            }
        }

        public void DeleteOrderItem(int orderItemID)
        {
            context.OrderItems.Remove(context.OrderItems.FirstOrDefault(x => x.OrderItemID == orderItemID));
            context.SaveChanges();
        }

        public void EditOrderItemByAmount(OrderItem orderItem)
        {
           OrderItem item = context.OrderItems.Find(orderItem.OrderItemID);
           if(item != null)
           {
                  item.Ammount = orderItem.Ammount;
           }
           context.SaveChanges();
        }

        public void EditOrderItemByCompletedItem(int orderItemID, bool isCompleted)
        {
            OrderItem item = context.OrderItems.Find(orderItemID);
            if (item != null)
            {
                item.IsCompletedItem = isCompleted;
            }
            context.SaveChanges();
        }

        public void EditOrderItemByRestGoods(int orderItemID, int restGoods)
        {
            OrderItem item = context.OrderItems.Find(orderItemID);
            if (item != null)
            {
                item.RestGoods = restGoods;
            }
            context.SaveChanges();
        }
    }
}