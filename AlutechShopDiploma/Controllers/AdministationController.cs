using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    public class AdministationController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult UsersList(string ID,string name)
        {
            IEnumerable<ApplicationUser> Users;
            if (ID != null)
            {
                 Users = applicationDbContext.Users.Where(x => x.Id == ID);

            }
            else if(name != null)
            {
                Users = applicationDbContext.Users.Where(x => x.UserName == name);
            }
            else
            {
                 Users = applicationDbContext.Users;
            }
            return View(Users);
        }

        public ActionResult BlockUser(string userId)
        {
            ApplicationUser applicationUser = applicationDbContext.Users.Find(userId);
            applicationUser.isBanned = true;
            applicationDbContext.SaveChanges();
            TempData["succsess"] = string.Format("Пользователь " + applicationUser.UserName + " заблокирован.");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }
        
        public ActionResult UnlbockUser(string userId)
        {
            ApplicationUser applicationUser = applicationDbContext.Users.Find(userId);
            applicationUser.isBanned = false;
            applicationDbContext.SaveChanges();
            TempData["succsess"] = string.Format("Пользователь " + applicationUser.UserName + " разблокирован.");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());
            return Content("Message");
        }
        public ViewResult CommentsList(string commentId, string goodName,string userName)
        {
            IEnumerable<Comment> comments;
            if (commentId != null)
            {
                int comId = Convert.ToInt32(commentId);
                comments = applicationDbContext.Comments.Where(x => x.CommentID == comId);
            }
            else if (goodName != null)
            {
                Good good = applicationDbContext.Goods.FirstOrDefault(x => x.Name == goodName);
                comments = applicationDbContext.Comments.Where(x => x.GoodID == good.GoodID);
            }
            else if (userName != null)
            {
                ApplicationUser user = applicationDbContext.Users.FirstOrDefault(x => x.UserName == userName);
                comments = applicationDbContext.Comments.Where(x => x.UserID == user.Id);
            }
            else
            {
                comments = applicationDbContext.Comments;
            }
            return View(comments);
        }

        public PartialViewResult MessagesList(string messageId,string username)
        {
            IEnumerable<UserMessage> userMessages;
            if (messageId != null)
            {
                int mesId = Convert.ToInt32(messageId);
                userMessages = applicationDbContext.UserMessages.Where(x => x.UserMessageID == mesId);
            }
            else if (username != null)
            {
                ApplicationUser user = applicationDbContext.Users.FirstOrDefault(x => x.UserName == username);
                userMessages = applicationDbContext.UserMessages.Where(x => x.UserId == user.Id);
            }
            else
            {
                userMessages = applicationDbContext.UserMessages;
            }
            return PartialView(userMessages);
        }

        public PartialViewResult CategoriesList()
        {
            IEnumerable<Category> categories = applicationDbContext.Categories;
            return PartialView(categories);
        }

        public PartialViewResult GoodsList()
        {
            IEnumerable<Good> goods = applicationDbContext.Goods;
            return PartialView(goods);
        }

        public PartialViewResult DiscountsList()
        {
            IEnumerable<Discount> discounts = applicationDbContext.Discounts;
            return PartialView(discounts);
        }

        public PartialViewResult ImagesList()
        {
            IEnumerable<ImageContainer> images = applicationDbContext.ImageContainers;
            return PartialView(images);
        }

        public PartialViewResult WarehousesList()
        {
            IEnumerable<Warehouse> warehouses = applicationDbContext.Warehouses;
            return PartialView(warehouses);
        }

    }
}