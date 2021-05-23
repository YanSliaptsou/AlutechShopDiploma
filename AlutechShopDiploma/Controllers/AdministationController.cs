using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.Models.Abstract;

namespace AlutechShopDiploma.Controllers
{
    public class AdministationController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        ICategoryRepository categoryRepository;
        IDiscountRepository discountRepository;
        IImageContainerRepositiry imageContainerRepositiry;
        public ActionResult Index()
        {
            return View();
        }

        public AdministationController(ICategoryRepository _repoCateg, IDiscountRepository _repoDisc, IImageContainerRepositiry _repoImg)
        {
            categoryRepository = _repoCateg;
            discountRepository = _repoDisc;
            imageContainerRepositiry = _repoImg;
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

        public ViewResult MessagesList(string messageId,string username)
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
            return View(userMessages);
        }

        public ViewResult CategoriesList()
        {
            IEnumerable<Category> categories = applicationDbContext.Categories;
            return View(categories);
        }

        public ViewResult CreateСategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteСategory(int categoryId)
        {
            List<string> ids = sqlWorker.SelectDataFromDBMult("SELECT CategoryID from GoodsTables where CategoryID=" + categoryId);
            if (ids.Count == 0)
            {
                TempData["message"] = string.Format("Категория \"{0}\" удалена.", categoryRepository.Categories.FirstOrDefault(c => c.CategoryID == categoryId).Name);
                categoryRepository.DeleteCategory(categoryId);
            }
            else
            {
                TempData["mistake"] = string.Format("Невозможно удалить категорию!");
            }
            return RedirectToAction("CategoriesList");
        }

        [HttpPost]
        public ActionResult CreateСategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.CreateCategory(category);
                TempData["message"] = string.Format("Новый категория \"{0}\" успешно добавлена.", category.Name);
                return RedirectToAction("CategoriesList");
            }
            else
            {
                return View(category);
            }
        }
        [HttpGet]
        public ViewResult EditСategory(int categoryId)
        {
            Category category = categoryRepository.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditСategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.EditCategory(category);
                TempData["message"] = string.Format("Изменение информации о \"{0}\" сохранены", category.Name);
                return RedirectToAction("CategoriesList");
            }
            else
            {
                return View(category);
            }
        }


        public PartialViewResult GoodsList()
        {
            IEnumerable<Good> goods = applicationDbContext.Goods;
            return PartialView(goods);
        }

        public ViewResult DiscountsList(string discountId, string goodName)
        {
            IEnumerable<Discount> discounts;
            if (discountId != null)
            {
                int discId = Convert.ToInt32(discountId);
                discounts = applicationDbContext.Discounts.Where(x => x.DiscountID == discId);
            }
            else if (goodName != null)
            {
                Good good = applicationDbContext.Goods.FirstOrDefault(x => x.Name == goodName);
                discounts = applicationDbContext.Discounts.Where(x => x.GoodID == good.GoodID);
            }
            else
            {
                discounts = applicationDbContext.Discounts;
            }
            return View(discounts);
        }

        public ActionResult EditDiscount(Discount discount)
        {
            discountRepository.EditDiscont(discount);
            TempData["message"] = string.Format("Размер скидки сохранён");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ActionResult DeleteDiscount(int discountId)
        {
            discountRepository.DeleteDiscount(discountId);
            TempData["message"] = string.Format("Скидка удалена");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ViewResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDiscount(Discount discount)
        {
            if (ModelState.IsValid)
            {
                discountRepository.CreateDiscount(discount);
                TempData["message"] = string.Format("Скидка успешно добавлена");
                return RedirectToAction("DiscountsList");
            }
            else
            {
                return View(discount);
            }
        }

        public ViewResult ImagesList(string goodName)
        {
            IEnumerable<ImageContainer> images;
            if (goodName != null)
            {
                Good good = applicationDbContext.Goods.FirstOrDefault(x => x.Name == goodName);
                images = applicationDbContext.ImageContainers.Where(x => x.GoodID == good.GoodID);
            }
            else
            {
                images = applicationDbContext.ImageContainers;
            }
            return View(images);
        }

        public ActionResult EditImage(ImageContainer image)
        {
            imageContainerRepositiry.EditImage(image);
            TempData["message"] = string.Format("Изображение изменено");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ActionResult DeleteImage(int imageId)
        {
            discountRepository.DeleteDiscount(imageId);
            TempData["message"] = string.Format("Изображение удалено");
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

        public ViewResult CreateIamge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateImaget(ImageContainer image)
        {
            if (ModelState.IsValid)
            {
                imageContainerRepositiry.CreateImage(image);
                TempData["message"] = string.Format("Изображение успешно добавлено");
                return RedirectToAction("ImagesList");
            }
            else
            {
                return View(image);
            }
        }

        public PartialViewResult WarehousesList()
        {
            IEnumerable<Warehouse> warehouses = applicationDbContext.Warehouses;
            return PartialView(warehouses);
        }

    }
}