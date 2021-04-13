using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods
{
    public class AlutechBarrier
    {
        private int alutechBarrierID;
        private string workIntensity;
        private int torque; //крутящий момент
        private double maxTimeOpenClose;
        private int voltage;
        private int corpProtectionDegree;
        private int overlappingWidth; //Ширина перекрываемого проезда

        public int AlutechBarrierID { get => alutechBarrierID; set => alutechBarrierID = value; }
        public string WorkIntensity { get => workIntensity; set => workIntensity = value; }
        public int Torque { get => torque; set => torque = value; }
        public double MaxTimeOpenClose { get => maxTimeOpenClose; set => maxTimeOpenClose = value; }
        public int Voltage { get => voltage; set => voltage = value; }
        public int CorpProtectionDegree { get => corpProtectionDegree; set => corpProtectionDegree = value; }
        public int OverlappingWidth { get => overlappingWidth; set => overlappingWidth = value; }
    }
}