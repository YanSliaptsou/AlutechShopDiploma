using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_2
{
    public class BusProfile
    {
        private int busProfileID;
        private double weight;
        private string material;

        public int BusProfileID { get => busProfileID; set => busProfileID = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Material { get => material; set => material = value; }
    }
}