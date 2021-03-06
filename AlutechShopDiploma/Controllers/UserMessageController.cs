using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Concrete;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AlutechShopDiploma.Models;

namespace AlutechShopDiploma.Controllers
{
    public class UserMessageController : Controller
    {
        IUserMessageRepository repository;
        ApplicationDbContext context = new ApplicationDbContext();
        public UserMessageController(IUserMessageRepository rep)
        {
            repository = rep;
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(UserMessage message)
        {
            if (ModelState.IsValid)
            {
                EmailSettings emailSettings = new EmailSettings();
                EmailProcessor emailProcessor = new EmailProcessor(emailSettings);

                emailProcessor.ProcessUserMessage(message);

                repository.CreateMessage(message);
                TempData["succsess"] = string.Format("Вваше сообщение успешно отправлено");
            }
            else
            {
                TempData["mistake"] = string.Format("Произошла ошибка. Проверьте введённые данные.");
            }
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ActionResult AskToUnban()
        {
            EmailSettings settings = new EmailSettings();
            EmailProcessor processor = new EmailProcessor(settings);
            processor.ProcessAskingToUnbanUser(context.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name));
            TempData["succsess"] = string.Format("Заявка о вашей разблокировке подана.");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }
    }
}