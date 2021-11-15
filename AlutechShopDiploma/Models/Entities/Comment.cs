using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Comment
    {
        private int commentID;
        private string userID;
        private int goodID;
        private string commentText;
        private DateTime dateTime;

        public int CommentID { get => commentID; set => commentID = value; }
        public string UserID { get => userID; set => userID = value; }
        public int GoodID { get => goodID; set => goodID = value; }
        public string CommentText { get => commentText; set => commentText = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
    }
}