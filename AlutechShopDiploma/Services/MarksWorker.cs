using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Services
{
    public class MarksWorker
    {
        private int goodID;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        ApplicationDbContext context = new ApplicationDbContext();

        public MarksWorker(int usersGoodID)
        {
            goodID = usersGoodID;
        }

        public List<int> GetMarksList()
        {
            List<string> marksList = sqlWorker.SelectDataFromDBMult("SELECT UserMark from Marks WHERE GoodID = " + goodID);

            List<int> doubleMarksList = new List<int>();

            foreach (var element in marksList)
            {
                doubleMarksList.Add(Convert.ToInt32(element));
            }
            return doubleMarksList;
        }

        public double CountAvgMark()
        {
            List<int> marksList = GetMarksList();

            double sum = 0;
            double avgMark = 0;

            if (marksList.Count > 0)
            {
                foreach (var mark in marksList)
                {
                    sum += mark;
                }
                avgMark = Math.Round(sum / marksList.Count, 1);
            }
            return avgMark;
        }

        public void UpdateTable()
        {
            double avgMark = CountAvgMark();

            Good good = context.Goods.FirstOrDefault(g => g.GoodID == goodID);

            good.Rating = avgMark;

            context.SaveChanges();
        }

        public bool IsAvailableToPutMark(string username)
        {
            bool result = false;
            string mark = sqlWorker.SelectDataFromDB("SELECT UserMark from Marks WHERE UserID = (SELECT Id from AspNetUsers WHERE UserName = '" + username + "') AND GoodID = " + goodID);

            if(mark == "")
            {
                result = true;
            }

            return result;
        }

        public int GetMarkId(string username)
        {
            int result = 0;
            string mark = sqlWorker.SelectDataFromDB("SELECT MarkId from Marks WHERE UserID = (SELECT Id from AspNetUsers WHERE UserName = '" + username + "') AND GoodID = " + goodID);

            if (mark != "")
            {
                result = Convert.ToInt32(mark);
            }

            return result;
        }
    }
}