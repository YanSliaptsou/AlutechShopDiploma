using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Warehouse
    {
        private int warehouseID;
        private int goodID;
        private int goodAmmount;

        public int WarehouseID { get => warehouseID; set => warehouseID = value; }
        public int GoodAmmount { get => goodAmmount; set => goodAmmount = value; }
        public int GoodID { get => goodID; set => goodID = value; }
    }
}