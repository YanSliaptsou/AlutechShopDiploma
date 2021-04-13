using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class Clutch
    {
        private int clutchID;
        private double weight;
        private double shaftDiameter;
        private string material;
        private int deliveryRate;

        public int ClutchID { get => clutchID; set => clutchID = value; }
        public double Weight { get => weight; set => weight = value; }
        public double ShaftDiameter { get => shaftDiameter; set => shaftDiameter = value; }
        public string Material { get => material; set => material = value; }
        public int DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
    }
}