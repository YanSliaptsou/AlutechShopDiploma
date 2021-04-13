using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_1
{
    public class RecoilingGateOperatorAnMotors
    {
        private int recoilingGateOperatorAnMotorsID;
        private int approprTemperature;
        private double usangeIntensity;
        private int maxTorque;
        private int voltage;
        private int powerty;
        private int sashWeight;

        public int RecoilingGateOperatorAnMotorsID { get => recoilingGateOperatorAnMotorsID; set => recoilingGateOperatorAnMotorsID = value; }
        public int ApproprTemperature { get => approprTemperature; set => approprTemperature = value; }
        public double UsangeIntensity { get => usangeIntensity; set => usangeIntensity = value; }
        public int MaxTorque { get => maxTorque; set => maxTorque = value; }
        public int Voltage { get => voltage; set => voltage = value; }
        public int Powerty { get => powerty; set => powerty = value; }
        public int SashWeight { get => sashWeight; set => sashWeight = value; }
    }
}