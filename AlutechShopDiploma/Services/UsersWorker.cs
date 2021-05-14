using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Services
{
    public class UsersWorker
    {
        private string username;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public UsersWorker(string username)
        {
            this.username = username;
        }
        public string GetUserID()
        {
            return sqlWorker.SelectDataFromDB("SELECT Id from AspNetUsers WHERE UserName = '" + username + "'");
        }

        public double GetUserBalance()
        {
            return Convert.ToDouble(sqlWorker.SelectDataFromDB("SELECT bonusAmmount from AspNetUsers WHERE Id = '" + GetUserID() +"'"));
        }
    }
}