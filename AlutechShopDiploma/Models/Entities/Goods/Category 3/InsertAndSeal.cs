using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class InsertAndSeal
    {
        private int insertAndSealID;
        private double weight;
        private string material;
        private string deliveryRate; //норма поставки

        public int InsertAndSealID { get => insertAndSealID; set => insertAndSealID = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Material { get => material; set => material = value; }
        public string DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
    }
}