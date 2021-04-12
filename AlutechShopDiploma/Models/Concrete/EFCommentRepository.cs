using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFCommentRepository : ICommentRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public void CreateComment(Comment comment)
        {
            context.Comments.Add(
                new Comment
                {
                    CommentText = comment.CommentText,
                    GoodID = comment.GoodID,
                    UserID = comment.UserID,
                    DateTime = comment.DateTime
                });
            context.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            context.Comments.Remove(context.Comments.FirstOrDefault(x => x.CommentID == commentId));
            context.SaveChanges();
        }

        public void EditComment(Comment comment)
        {
            if (comment.CommentID == 0)
            {
                context.Comments.Add(comment);
            }
            else
            {
                Comment dbEntry = context.Comments.Find(comment.CommentID);
                if (dbEntry != null)
                {
                    dbEntry.CommentText = comment.CommentText;
                    dbEntry.GoodID = comment.GoodID;
                    dbEntry.UserID = comment.UserID;
                    dbEntry.DateTime = comment.DateTime;
                }
            }
            context.SaveChanges();
        }
    }
}