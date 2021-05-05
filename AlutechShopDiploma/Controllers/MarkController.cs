using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class MarkController : Controller
    {
        IMarkRepository repository;
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public MarkController(IMarkRepository rep)
        {
            repository = rep;
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Mark mark)
        {
            if (ModelState.IsValid)
            {
                repository.CreateMark(mark);
                TempData["succsess"] = string.Format("Вы успешно оценили товар. Ваша оценка - " + mark.UserMark);
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка.");
            }

            MarksWorker marksWorks = new MarksWorker(GoodItemController.goodID);

            marksWorks.UpdateTable();

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }

        public ActionResult Delete(int markID)
        {
            int goodID = Convert.ToInt32(sqlWorker.SelectDataFromDB("SELECT GoodID FROM Marks WHERE MarkId = " + markID));
            string userMark = sqlWorker.SelectDataFromDB("SELECT UserMark FROM Marks WHERE MarkId = " + markID);

            TempData["succsess"] = string.Format("Ваша оценка " +userMark+" была успешно удалена. Теперь можете заново оценить товар.");
            repository.DeleteMark(markID);

           

            MarksWorker marksWorks = new MarksWorker(goodID);

            marksWorks.UpdateTable();


            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }
    }
}