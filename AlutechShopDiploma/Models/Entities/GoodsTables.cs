using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class GoodsTable
    {
        private int goodsTableID;
        private string tableName;
        private int categoryID;

        public int GoodsTableID { get => goodsTableID; set => goodsTableID = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
    }
}