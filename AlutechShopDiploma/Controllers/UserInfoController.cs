using AlutechShopDiploma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.Services;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models.ViewModels;
using SimpleChart = System.Web.Helpers;
namespace AlutechShopDiploma.Controllers
{
    public class UserInfoController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public UserInfoController()
        {
            
        }

        public PartialViewResult MessagesList()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            IEnumerable<UserMessage> messages = usersWorker.GetMessagesList();
            return PartialView(messages);
        }
        public PartialViewResult MarksList()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            IEnumerable<Mark> marks = usersWorker.GetMarksList();
            return PartialView(marks);
        }
        public PartialViewResult CommentsList()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            IEnumerable<Comment> comments = usersWorker.GetCommentsList();
            return PartialView(comments);
        }
        public PartialViewResult OrdersList()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            IEnumerable<Order> orders = usersWorker.GetOrdersList();
            return PartialView(orders);
        }

        public PartialViewResult BonusBalance()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            string userId = usersWorker.GetUserID();
            double userBalance = usersWorker.GetUserBalance();
            IEnumerable<Order> orders = usersWorker.GetOrdersList();

            UserBalanceViewModel userBalanceViewModel = new UserBalanceViewModel
            {
                orders = orders,
                userBalance = userBalance
            };

            return PartialView(userBalanceViewModel);
        }

        public PartialViewResult Statistics()
        {
            IndexViewModel model = ManageController.model;
            return PartialView(model);
        }
        public PartialViewResult Graphics()
        {
            return PartialView();
        }

        public ActionResult CreatePurchasesGoodsChart()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            Dictionary<Good, int> uniqieGoods = usersWorker.GetGoodsCountInAllOrders();

            string[] goodsName = new string[uniqieGoods.Count];
            int[] goodsAmmounts = new int[uniqieGoods.Count];

            int i = 0;

            foreach(var element in uniqieGoods.Keys)
            {
                goodsName[i] = element.Name;
                i++;
            }

            i = 0;

            foreach (var element in uniqieGoods.Values)
            {
                goodsAmmounts[i] = element;
                i++;
            }


            var chart = new SimpleChart.Chart(width: 1100, height: 1000)
              .AddTitle("Покупки товаров/Goods purchases")
              .AddSeries(
                     name: "Количество товаров/Goods ammount",
                     chartType: "Column",
                     xValue: goodsName,
                     yValues: goodsAmmounts)
              .AddLegend()
              .Write();


            return null;
        }

        public ActionResult CreateBonusAmmountDynamicChart()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);
            Dictionary<DateTime, double> spends = usersWorker.GetSpendsOfBonusAmmount();
            Dictionary<DateTime, double> ads = usersWorker.GetAddsToBonusAmmount();
            Dictionary<DateTime, double> bonusAmmount = usersWorker.GetBonusAmmountState();

            string[] datetime = new string[bonusAmmount.Count];
            double[] spendsArray = spends.Values.ToArray();
            double[] adsArray = ads.Values.ToArray();
            double[] bonusAmmountsArray = bonusAmmount.Values.ToArray();

            int i = 0;
            foreach(var element in bonusAmmount.Keys)
            {
                datetime[i] = element.Day + "." + element.Month + "." + element.Year + " " + element.Hour + ":" + element.Minute + ":" + element.Second;
                i++;
            }

            var chart = new SimpleChart.Chart(width: 1100, height: 1000)
              .AddTitle("Движение средств по бонуснуму балансу/The movement of funds on the bonus balance")
              .AddSeries(
                     name: "Списания баланса/Balance write-offs",
                     chartType: "Line",
                     xValue: datetime,
                     yValues: spendsArray)
              .AddLegend()
              .AddSeries(
                     name: "Пополнения баланса/Balance replenishment",
                     chartType: "Line",
                     xValue: datetime,
                     yValues: adsArray)
              .AddLegend()
              .AddSeries(
                     name: "Баланс/Balance",
                     chartType: "Line",
                     xValue: datetime,
                     yValues: bonusAmmountsArray)
              .AddLegend()
              .Write();

            return null;
        }

        public ActionResult CreateCommentsAmmountChart()
        {
            UsersWorker usersWorker = new UsersWorker(HttpContext.User.Identity.Name);

            Dictionary<Good, int> comments = usersWorker.GetCommentsAmmountOnGoods();

            string[] goodsNames = new string[comments.Count];

            int i = 0;
            foreach(var comment in comments.Keys)
            {
                goodsNames[i] = comment.Name;
                i++;
            }

            int[] ammounts = comments.Values.ToArray();

            var chart = new SimpleChart.Chart(width: 1100, height: 1000)
              .AddTitle("Отзывы/Reviews")
              .AddSeries(
                     name: "Количество отзывов/Ammount od reviews",
                     chartType: "Column",
                     xValue: goodsNames,
                     yValues: ammounts)
              .AddLegend()
              .Write();

            return null;
        }
    }
}