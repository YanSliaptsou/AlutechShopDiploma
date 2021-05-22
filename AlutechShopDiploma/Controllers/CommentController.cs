using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Controllers
{
    public class CommentController : Controller
    {
        ICommentRepository repository;

        public CommentController(ICommentRepository rep)
        {
            repository = rep;
        }

        public PartialViewResult List()
        {
            return PartialView(repository.Comments);
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid && comment.CommentText != null)
            {
                repository.CreateComment(comment);
                TempData["succsess"] = string.Format("Комментарий успешно добавлен");
            }
            else if (comment.CommentText == null)
            {
                TempData["mistake"] = string.Format("Произошла ошибка. Проверьте ваш комментарий.");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public PartialViewResult Edit(int commentID)
        {
            Comment comment = repository.Comments.FirstOrDefault(c => c.CommentID == commentID);
            return PartialView(comment);
        }

        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                repository.EditComment(comment);
                TempData["succsess"] = string.Format("Ваш комментарий успешно изменён");
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка. Проверьте ваш комментарий.");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ActionResult Delete(int commentID)
        {

            TempData["message"] = string.Format("Комментарий удалён");
            repository.DeleteComment(commentID);

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }
    }
}