using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Controllers;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFMarkRepository : IMarkRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public IEnumerable<Mark> Marks
        {
            get { return context.Marks; }
        }

        public void CreateMark(Mark mark)
        {
            var name = HttpContext.Current.User.Identity.Name;
            string userID = sqlWorker.SelectDataFromDB("SELECT Id FROM AspNetUsers WHERE UserName = '" + name + "'");
            context.Marks.Add(
                new Mark
                {
                    UserMark = mark.UserMark,
                    GoodID = GoodItemController.goodID,
                    UserID = userID,
                });
            context.SaveChanges();
        }

        public void DeleteMark(int goodMarkID)
        {
            context.Marks.Remove(context.Marks.FirstOrDefault(x => x.MarkID == goodMarkID));
            context.SaveChanges();
        }

        public void EditMark(Mark mark)
        {
            Mark myMark = context.Marks.Find(mark.MarkID);
            myMark.UserMark = mark.UserMark;
            context.SaveChanges();
        }
    }
}