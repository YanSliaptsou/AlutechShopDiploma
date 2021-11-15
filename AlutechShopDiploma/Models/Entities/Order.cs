using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Order
    {
        private int orderID;
        private string userID;
        private double totalSum;
        private DateTime dateTime;
        private string shopCardSessionID;
        private bool isFinished;
        private bool isOrdered;

        public int OrderID { get => orderID; set => orderID = value; }
        public string UserID { get => userID; set => userID = value; }
        public double TotalSum { get => totalSum; set => totalSum = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string ShopCardSessionID { get => shopCardSessionID; set => shopCardSessionID = value; }
        public bool IsFinished { get => isFinished; set => isFinished = value; }
        public bool IsOrdered { get => isOrdered; set => isOrdered = value; }
    }
}