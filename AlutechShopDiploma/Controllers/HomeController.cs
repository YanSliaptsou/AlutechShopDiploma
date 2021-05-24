using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AlutechShopDiploma.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public IGoodRepository repository;
        public int pageSize = 3;
        

        public HomeController(IGoodRepository repo)
        {
            repository = repo;
        }

        [Authorize]
        public ActionResult Index()
        {
            /*IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);*/
            IEnumerable<Good> goods = repository.Goods;

            return View(goods);
        }

        public ActionResult About()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            IEnumerable<Discount> discounts = applicationDbContext.Discounts.Where(x => x.DiscountID !=0);

            return View(discounts);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetInfo()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = HttpContext.User.Identity.Name;
            var age = identity.Claims.Where(c => c.Type == "age").Select(c => c.Value).SingleOrDefault();
            return "<p>Эл. адрес: " + email + "</p><p> Возраст:" + age + "</p>";
        }
    }
}