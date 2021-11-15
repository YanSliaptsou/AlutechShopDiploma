using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class Loop
    {
        private int loopID;
        private double weight;
        private string material;
        private int deliveryRate;

        public int LoopID { get => loopID; set => loopID = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Material { get => material; set => material = value; }
        public int DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
    }
}