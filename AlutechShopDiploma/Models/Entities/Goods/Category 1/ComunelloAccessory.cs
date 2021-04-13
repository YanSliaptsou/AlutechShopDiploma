using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods
{
    public class ComunelloAccessory
    {
        private int comunelloAccessoryID;
        private string gabariteSizes;
        private int indoorLightLength;
        private int outdoorLightLength;
        private string temperatureRange;
        private int voltage;
        private string outputContactsType;

        public int ComunelloAccessoryID { get => comunelloAccessoryID; set => comunelloAccessoryID = value; }
        public string GabariteSizes { get => gabariteSizes; set => gabariteSizes = value; }
        public int IndoorLightLength { get => indoorLightLength; set => indoorLightLength = value; }
        public int OutdoorLightLength { get => outdoorLightLength; set => outdoorLightLength = value; }
        public string TemperatureRange { get => temperatureRange; set => temperatureRange = value; }
        public int Voltage { get => voltage; set => voltage = value; }
        public string OutputContactsType { get => outputContactsType; set => outputContactsType = value; }
    }
}