using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlutechShopDiploma.Models.Entities;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> OrderItems { get; }
        void CreateOrderItem(OrderItem orderItem);
        void EditOrderItemByAmount(OrderItem orderItem);
        void EditOrderItemByCompletedItem(int orderItemID, bool isCompleted);
        void EditOrderItemByRestGoods(int orderItemID, int restGoods);
        void DeleteOrderItem(int orderItemID);
    }
}
