using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods
{
    public class AdditionalComplectation
    {
        private int additionalComplectationID;
        private double netWeight;

        public int AdditionalComplectationID { get => additionalComplectationID; set => additionalComplectationID = value; }
        public double NetWeight { get => netWeight; set => netWeight = value; }
    }
}