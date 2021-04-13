using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_1
{
    public class GarageGateOperatorAnMotors
    {
        private int garageGateOperatorAnMotorsID;
        private int usageIntensity;
        private double maxGatesHeight;
        private double maxGatesSquare;
        private int tractiveEffort;
        private int electricalMotor;

        public int GarageGateOperatorAnMotorsID { get => garageGateOperatorAnMotorsID; set => garageGateOperatorAnMotorsID = value; }
        public int UsageIntensity { get => usageIntensity; set => usageIntensity = value; }
        public double MaxGatesHeight { get => maxGatesHeight; set => maxGatesHeight = value; }
        public double MaxGatesSquare { get => maxGatesSquare; set => maxGatesSquare = value; }
        public int TractiveEffort { get => tractiveEffort; set => tractiveEffort = value; }
        public int ElectricalMotor { get => electricalMotor; set => electricalMotor = value; }
    }
}