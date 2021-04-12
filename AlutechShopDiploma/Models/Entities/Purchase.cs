using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Purchase
    {
        private int purchaseID;
        private int goodId;
        private int ammount;

        public int PurchaseID { get => purchaseID; set => purchaseID = value; }
        public int GoodId { get => goodId; set => goodId = value; }
        public int Ammount { get => ammount; set => ammount = value; }
    }
}