using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Discount
    {
        private int discountID;
        private int goodID;
        private int discountAmmount;

        public int DiscountID { get => discountID; set => discountID = value; }
        public int GoodID { get => goodID; set => goodID = value; }
        public int DiscountAmmount { get => discountAmmount; set => discountAmmount = value; }
    }
}