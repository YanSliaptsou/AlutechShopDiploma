using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models;

namespace AlutechShopDiploma.Services
{
    public class AdminStatisticsGetter
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public int GetMarksAmmount()
        {
            return context.Marks.Count();
        }

        public (int, string) GetmaxMarksCount()
        {
            (int, string) tuple;
            int count = 0;
            string name = "";
            foreach (var good in context.Goods.ToList())
            {
                int countC = context.Marks.Where(c => c.GoodID == good.GoodID).Count();
                if (countC > count)
                {
                    count = countC;
                    name = good.Name;
                }
            }
            tuple = (count, name);
            return tuple;
        }

        public int GetCommentsCount()
        {
            return context.Comments.Count();
        }

        public (int,string) GetmaxCommentsCount()
        {
            (int, string) tuple;
            int count = 0;
            string name = "";
            foreach(var good in context.Goods.ToList())
            {
                int countC = context.Comments.Where(c => c.GoodID == good.GoodID).Count();
                if(countC > count)
                {
                    count = countC;
                    name = good.Name;
                }
            }
            tuple = (count, name);
            return tuple;
        }

        public int GetMessagesAmmount()
        {
            return context.UserMessages.Count();
        }

        public int GetUsersAmmount()
        {
            return context.Users.Count();
        }

        public int GetBlockedUsersAmmount()
        {
            return context.Users.Where(c => c.isBanned == true).Count();
        }

        public int GetNotBlockedUsersAmmount()
        {
            return context.Users.Where(c => c.isBanned == false).Count();
        }

        public double GetBonusAmmountTotal()
        {
            IEnumerable<ApplicationUser> users = context.Users.ToList();

            double ammount = 0;
            foreach(var user in users)
            {
                ammount += user.bonusAmmount;
            }

            return ammount;
        }

        public double GetBonusAmmountAvg()
        {
            IEnumerable<ApplicationUser> users = context.Users.ToList();

            double ammount = 0;
            foreach (var user in users)
            {
                ammount += user.bonusAmmount;
            }

            return Math.Round(ammount/users.Count(),2);
        }

        public double AvgGoodPrice()
        {
            IEnumerable<Good> goods = context.Goods.ToList();

            double price = 0;
            foreach(var good in goods)
            {
                price += good.Price;
            }

            return Math.Round(price / goods.Count(),2);
        }

        public double GetAvgRating()
        {
            double rating = 0;
            foreach (var good in context.Goods.ToList())
            {
                rating += good.Rating;
            }
            return Math.Round(rating / context.Goods.Count(),2);
        }

        public (double, string) GetMaxGoodRating()
        {
            (double, string) tuple;
            double rating = 0;
            string name = "";
            foreach (var good in context.Goods.ToList())
            {
                double rat = context.Goods.Find(good.GoodID).Rating;
                if (rat > rating)
                {
                    rating = rat;
                    name = good.Name;
                }
            }
            tuple = (rating, name);
            return tuple;
        }

        public int GetTotalViews()
        {
            int views = 0;

            foreach(var good in context.Goods.ToList())
            {
                views += good.Views;
            }

            return views;
        }

        public double GetAvgViews()
        {
            double views = 0;
            foreach(var good in context.Goods.ToList())
            {
                views += good.Views;
            }

            return Math.Round(views / context.Goods.Count(), 2);
        }

        public (int, string) GetMaxGoodViews()
        {
            (int, string) tuple;
            int views = 0;
            string name = "";
            foreach (var good in context.Goods.ToList())
            {
                int viewS = context.Goods.Find(good.GoodID).Views;
                if (viewS > views)
                {
                    views = viewS;
                    name = good.Name;
                }
            }
            tuple = (views, name);
            return tuple;
        }

        public double GetOrdersAmmount()
        {
            double ammount = 0;
            foreach(var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetOrdersCount();
            }
            return ammount;
        }

        public double GetOrderedOrdersAmmount()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetOrderedOrdersCount();
            }
            return ammount;
        }

        public double GetNotOrderedOrdersAmmount()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetNotOrderedOrdersCount();
            }
            return ammount;
        }

        public double GetTotalAmountOrderedGoods()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetTotalGoodsAmmountInAllOrders();
            }
            return ammount;
        }

        public double GetTotalUniqueAmountOrderedGoods()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetTotalUniqueGoodsAmmountInAllOrders();
            }
            return ammount;
        }

        public double GetTotalSumOfAllOrders()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetTotalOrdersSum();
            }
            return ammount;
        }

        public double GetAddedBonusesSumOfAllOrders()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetTotalBonusesAdded();
            }
            return ammount;
        }

        public double GetSpentBonusesSumOfAllOrders()
        {
            double ammount = 0;
            foreach (var user in context.Users.ToList())
            {
                UsersWorker usersWorker = new UsersWorker(user.UserName);
                ammount += usersWorker.GetTotalBonusesSpent();
            }
            return ammount;
        }
    }
}