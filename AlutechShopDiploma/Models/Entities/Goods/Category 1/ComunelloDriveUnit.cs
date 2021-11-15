using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods
{
    public class ComunelloDriveUnit
    {
        private int comunelloDriveUnitID;
        private string usageIntensity;
        private double maxGatesHeight;
        private double maxGatesSquare;
        private double maxGatesSpeed;
        private int trativeEffort; //тяговое усилие
        private string electricMotor;

        public int ComunelloDriveUnitID { get => comunelloDriveUnitID; set => comunelloDriveUnitID = value; }
        public string UsageIntensity { get => usageIntensity; set => usageIntensity = value; }
        public double MaxGatesHeight { get => maxGatesHeight; set => maxGatesHeight = value; }
        public double MaxGatesSquare { get => maxGatesSquare; set => maxGatesSquare = value; }
        public double MaxGatesSpeed { get => maxGatesSpeed; set => maxGatesSpeed = value; }
        public int TrativeEffort { get => trativeEffort; set => trativeEffort = value; }
        public string ElectricMotor { get => electricMotor; set => electricMotor = value; }
    }
}