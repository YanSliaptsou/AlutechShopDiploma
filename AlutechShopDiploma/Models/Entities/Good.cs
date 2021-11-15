using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Good
    {
        private int goodID;
        private string name;
        private string description;
        private double price;
        private double rating;
        private int views;
        private int tableID;
        private int itemID;

        public int GoodID { get => goodID; set => goodID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public double Rating { get => rating; set => rating = value; }
        public int Views { get => views; set => views = value; }
        public int TableID { get => tableID; set => tableID = value; }
        public int ItemID { get => itemID; set => itemID = value; }
    }
}