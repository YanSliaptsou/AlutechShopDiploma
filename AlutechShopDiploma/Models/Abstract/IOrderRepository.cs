using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlutechShopDiploma.Models.Entities;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void CreateOrder();
        void EditOrderByTotalPrice(int orderID, double totalPrice);
        void EditOrderByIsFinished(int orderID, bool isFinished);
        void EditOrderByIsOrdered(int orderID, bool isOrdered);
        void DeleteOrder(int orderID);
    }
}
