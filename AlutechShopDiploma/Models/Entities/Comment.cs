using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class Comment
    {
        private int commentID;
        private ApplicationUser user;
        private Good good;
        private string commentText;
        private DateTime dateTime;

        public int CommentID { get => commentID; set => commentID = value; }
        public ApplicationUser User { get => user; set => user = value; }
        public Good Good { get => good; set => good = value; }
        public string CommentText { get => commentText; set => commentText = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
    }
}