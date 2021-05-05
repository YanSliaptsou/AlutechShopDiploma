using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Mark
    {
        private int markID;
        private int userMark;
        private int goodID;
        private string userID;

        public int MarkID { get => markID; set => markID = value; }
        public int UserMark { get => userMark; set => userMark = value; }
        public int GoodID { get => goodID; set => goodID = value; }
        public string UserID { get => userID; set => userID = value; }
        
    }
}