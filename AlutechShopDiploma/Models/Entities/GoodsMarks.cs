using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class GoodMarks
    {
        private int goodMarksID;
        private int amountOfMarks;
        private int totalMark;
        private int goodID;

        public int GoodMarksID { get => goodMarksID; set => goodMarksID = value; }
        public int AmountOfMarks { get => amountOfMarks; set => amountOfMarks = value; }
        public int TotalMark { get => totalMark; set => totalMark = value; }
        public int GoodID { get => goodID; set => goodID = value; }
    }
}