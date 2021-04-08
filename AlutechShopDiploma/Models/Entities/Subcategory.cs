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
        private Category category;

        public int SubcategoryID { get => subcategoryID; set => subcategoryID = value; }
        public string Name { get => name; set => name = value; }
        public Category Category { get => category; set => category = value; }
    }
}