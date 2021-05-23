using AlutechShopDiploma.Models;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Entities;
namespace AlutechShopDiploma.Services
{
    public class UsersWorker
    {
        private string username;
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public UsersWorker(string username)
        {
            this.username = username;
        }
        public string GetUserID()
        {
            return sqlWorker.SelectDataFromDB("SELECT Id from AspNetUsers WHERE UserName = '" + username + "'");
        }

        public string GetUserRole()
        {
            string userID = GetUserID();
            ApplicationUser applicationUser = applicationDbContext.Users.Find(userID);

            string roleID = sqlWorker.SelectDataFromDB("SELECT RoleID FROM AspNetUserRoles WHERE UserID = '" + applicationUser.Id +"'");
            string roleName = sqlWorker.SelectDataFromDB("SELECT Name FROM AspNetRoles WHERE Id = '" + roleID + "'");

            return roleName;
        }

        public double GetUserBalance()
        {
            return Convert.ToDouble(sqlWorker.SelectDataFromDB("SELECT bonusAmmount from AspNetUsers WHERE Id = '" + GetUserID() +"'"));
        }

        public bool GetUserStatus()
        {
            string userId = GetUserID();
            ApplicationUser user = applicationDbContext.Users.Find(userId);
            return user.isBanned;
        }

        public IEnumerable<UserMessage> GetMessagesList()
        {
            string userId = GetUserID();
            IEnumerable<UserMessage> messages = applicationDbContext.UserMessages.Where(x => x.UserId == userId).ToList();
            return messages;
        }

        public IEnumerable<Mark> GetMarksList()
        {
            string userId = GetUserID();
            IEnumerable<Mark> marks = applicationDbContext.Marks.Where(x => x.UserID == userId).ToList();
            return marks;
        }

        public IEnumerable<Comment> GetCommentsList()
        {
            string userId = GetUserID();
            IEnumerable<Comment> comments = applicationDbContext.Comments.Where(x => x.UserID == userId).ToList();
            return comments;
        }

        public IEnumerable<Order> GetOrdersList()
        {
            string userId = GetUserID();
            IEnumerable<Order> orders = applicationDbContext.Orders.Where(x => x.UserID == userId).ToList();
            return orders;
        }

        public IEnumerable<Order> GetOrderedOrdersList()
        {
            string userId = GetUserID();
            IEnumerable<Order> orders = applicationDbContext.Orders.Where(x => x.UserID == userId && x.IsOrdered == true).ToList();
            return orders;
        }

        public IEnumerable<Order> GetNotOrderedOrdersList()
        {
            string userId = GetUserID();
            IEnumerable<Order> orders = applicationDbContext.Orders.Where(x => x.UserID == userId && x.IsOrdered == false).ToList();
            return orders;
        }

        public int GetMessagesAmmount()
        {
            return GetMessagesList().Count();
        }

        public int GetMarksAmmount()
        {
            return GetMarksList().Count();
        }

        public double GetAvgMark()
        {
            double avgMark = 0;

            if(GetMarksList().Count() > 0)
            {
                double totalMark = 0;
                
                foreach (var item in GetMarksList())
                {
                    totalMark += item.UserMark;
                }
                avgMark = Math.Round(totalMark / GetMarksList().Count(),1);
            }
            return avgMark;
        }

        public double GetOrdersCount()
        {
            return GetOrdersList().Count();
        }

        public double GetOrderedOrdersCount()
        {
            return GetOrderedOrdersList().Count();
        }

        public double GetNotOrderedOrdersCount()
        {
            return GetNotOrderedOrdersList().Count();
        }

        public double GetCommentsCount()
        {
            return GetCommentsList().Count();
        }

        public double GetTotalOrdersSum()
        {
            double totalSum = 0;
            OrderWorker orderWorker = new OrderWorker();
            
            foreach(var item in GetOrderedOrdersList())
            {
                totalSum += orderWorker.GetOrderPrice(item);
            }

            return totalSum;
        }

        public Dictionary<DateTime, double> GetAddsToBonusAmmount()
        {
            Dictionary<DateTime, double> bonusAmmounts = new Dictionary<DateTime, double>();
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList())
            {
                bonusAmmounts.Add(item.DateTime, orderWorker.CountUserBonus(item));
            }

            return bonusAmmounts;
        }

        public Dictionary<DateTime, double> GetBonusAmmountState()
        {
            double totalBonus = 300;
            Dictionary<DateTime, double> bonusAmmounts = new Dictionary<DateTime, double>();
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList())
            {
                double x = orderWorker.CountOrderPrice(item);
                double y = orderWorker.GetOrderPrice(item);
                totalBonus += orderWorker.CountUserBonus(item) - Math.Round(orderWorker.CountOrderPrice(item) - orderWorker.GetOrderPrice(item), 2);
                bonusAmmounts.Add(item.DateTime, totalBonus);
            }

            return bonusAmmounts;
        }

        public Dictionary<DateTime, double> GetSpendsOfBonusAmmount()
        {
            Dictionary<DateTime, double> bonusAmmounts = new Dictionary<DateTime, double>();
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList())
            {
                bonusAmmounts.Add(item.DateTime, Math.Round(orderWorker.CountOrderPrice(item) - orderWorker.GetOrderPrice(item), 2));
            }

            return bonusAmmounts;
        }

        public double GetTotalBonusesAdded()
        {
            double totalSum = 0;
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList())
            {
                totalSum += orderWorker.CountUserBonus(item);
            }

            return totalSum;
        }

        public double GetTotalBonusesSpent()
        {
            double totalSum = 0;
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList())
            {
                totalSum += Math.Round(orderWorker.CountOrderPrice(item) - orderWorker.GetOrderPrice(item), 2);
            }

            return Math.Abs(totalSum);
        }

        public int GetTotalGoodsAmmountInAllOrders()
        {
            int totalCount = 0;
            OrderWorker orderWorker = new OrderWorker();

            foreach (var item in GetOrderedOrdersList().ToList())
            {
                IEnumerable<OrderItem> orderItems = applicationDbContext.OrderItems.Where(x => x.OrderID == item.OrderID);
                foreach(var orderItem in orderItems)
                {
                    totalCount += orderItem.Ammount;
                }
            }

            return totalCount;
        }

        public Dictionary<Good,int> GetGoodsCountInAllOrders()
        {
            Dictionary<Good, int> goodsDictionary = new Dictionary<Good, int>();
            List<Good> uniqueGoods = GetUniqueGoodsInAllOrders().ToList();

            foreach(var good in uniqueGoods)
            {
                int ammount = 0;
                foreach(var item in GetOrderedOrdersList().ToList())
                {
                    IEnumerable<OrderItem> orderItems = applicationDbContext.OrderItems.Where(x => x.OrderID == item.OrderID);
                    foreach (var orderItem in orderItems)
                    {
                        if(good.GoodID == orderItem.GoodID)
                        {
                            ammount += orderItem.Ammount;
                        }
                    }
                }
                goodsDictionary.Add(good, ammount);
            }

            return goodsDictionary;
        }

        public int GetTotalUniqueGoodsAmmountInAllOrders()
        {
            List<OrderItem> ordItems = new List<OrderItem>();

            foreach (var item in GetOrderedOrdersList().ToList())
            {
                IEnumerable<OrderItem> orderItems = applicationDbContext.OrderItems.Where(x => x.OrderID == item.OrderID);
                foreach (var orderItem in orderItems)
                {
                    if(!CheckIfListContains(ordItems,orderItem))
                    {
                        ordItems.Add(orderItem);
                    }
                }
            }

            return ordItems.Count();
        }


        public List<Good> GetUniqueGoodsInAllOrders()
        {
            List<Good> goods = new List<Good>();
            List<OrderItem> ordItems = new List<OrderItem>();

            foreach (var item in GetOrderedOrdersList().ToList())
            {
                IEnumerable<OrderItem> orderItems = applicationDbContext.OrderItems.Where(x => x.OrderID == item.OrderID).ToList();
                foreach (var orderItem in orderItems)
                {
                    if (!CheckIfListContains(ordItems, orderItem))
                    {
                        ordItems.Add(orderItem);
                        goods.Add(applicationDbContext.Goods.Find(orderItem.GoodID));
                    }
                }
            }

            return goods;
        }

        public bool CheckIfListContains(List<OrderItem> list, OrderItem orderItem)
        {
            bool flag = false;

            foreach(var item in list)
            {
                if(item.GoodID == orderItem.GoodID)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool CheckIfListContains(List<Good> list, Good good)
        {
            bool flag = false;

            foreach (var item in list)
            {
                if (item.GoodID == good.GoodID)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public Dictionary<Good,int> GetCommentsAmmountOnGoods()
        {
            Dictionary<Good, int> comments = new Dictionary<Good, int>();
            IEnumerable<Comment> commnts = GetCommentsList();
            List<Good> goods = new List<Good>();

            foreach(var comment in commnts)
            {
                Good good = applicationDbContext.Goods.Find(comment.GoodID);
                int ammount = applicationDbContext.Comments.Where(x => x.GoodID == good.GoodID).Count();

                if(!CheckIfListContains(goods,good))
                {
                    goods.Add(good);
                    comments.Add(good, ammount);
                }
            }

            return comments;
        }
    }
}