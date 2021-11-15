using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class RollerAndRing
    {
        private int rollerAndRingID;
        private double weight;
        private double axisDiameter;
        private double axisLength;
        private int deliveryRate;
        private string rollerAx;

        public int RollerAndRingID { get => rollerAndRingID; set => rollerAndRingID = value; }
        public double Weight { get => weight; set => weight = value; }
        public double AxisDiameter { get => axisDiameter; set => axisDiameter = value; }
        public double AxisLength { get => axisLength; set => axisLength = value; }
        public int DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
        public string RollerAx { get => rollerAx; set => rollerAx = value; }
    }
}