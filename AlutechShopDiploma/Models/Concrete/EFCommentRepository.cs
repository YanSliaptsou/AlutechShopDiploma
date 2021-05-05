using AlutechShopDiploma.Controllers;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFCommentRepository : ICommentRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");


        public IEnumerable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public void CreateComment(Comment comment)
        {
            var name = HttpContext.Current.User.Identity.Name;
            string userID = sqlWorker.SelectDataFromDB("SELECT Id FROM AspNetUsers WHERE UserName = '" + name + "'");
            context.Comments.Add(
                new Comment
                {
                    CommentText = comment.CommentText,
                    GoodID = GoodItemController.goodID,
                    UserID = userID,
                    DateTime = DateTime.Now,
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
                    dbEntry.DateTime = DateTime.Now;
                }
            }
            context.SaveChanges();
        }
    }
}