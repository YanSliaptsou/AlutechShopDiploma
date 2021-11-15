using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class Bracket
    {
        private int bracketID;
        private double weight;
        private string material;
        private int deliveryRate;
        private string rollerAxis;
        private string usage;

        public int BracketID { get => bracketID; set => bracketID = value; }
        public double Weight { get => weight; set => weight = value; }
        public int DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
        public string RollerAxis { get => rollerAxis; set => rollerAxis = value; }
        public string Usage { get => usage; set => usage = value; }
        public string Material { get => material; set => material = value; }
    }
}