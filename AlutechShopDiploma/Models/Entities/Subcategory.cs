using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Subcategory
    {
        private int subcategoryID;
        private string name;
        private int categoryId;

        public int SubcategoryID { get => subcategoryID; set => subcategoryID = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
    }
}