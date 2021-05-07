using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class OrderItem
    {
        private int orderItemID;
        private int goodID;
        private int ammount;
        private int restGoods;
        private bool isCompletedItem;
        private int orderID;
        private string shopCardSessionID;

        public int OrderItemID { get => orderItemID; set => orderItemID = value; }
        public int GoodID { get => goodID; set => goodID = value; }
        public int Ammount { get => ammount; set => ammount = value; }
        public int RestGoods { get => restGoods; set => restGoods = value; }
        public bool IsCompletedItem { get => isCompletedItem; set => isCompletedItem = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public string ShopCardSessionID { get => shopCardSessionID; set => shopCardSessionID = value; }
    }
}