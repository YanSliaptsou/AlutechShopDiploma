using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Category
    {
        private int categoryID;
        private string name;
        private string description;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}