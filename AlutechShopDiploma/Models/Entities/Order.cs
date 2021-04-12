using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Order
    {
        private int orderID;
        private string userId;
        private int puchaseID; 
        private double totalSum;
        private DateTime orderTime;

        public int OrderId { get => orderID; set => orderID = value; }
        public string UserId { get => userId; set => userId = value; }
        public double TotalSum { get => totalSum; set => totalSum = value; }
        public DateTime OrderTime { get => orderTime; set => orderTime = value; }
        public int PuchaseID { get => puchaseID; set => puchaseID = value; }
    }
}