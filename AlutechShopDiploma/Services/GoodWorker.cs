using AlutechShopDiploma.Models;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Services
{
    public class GoodWorker
    {
        private int goodID;
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public GoodWorker(int _goodID)
        {
            goodID = _goodID;
        }

        public double CalculateGoodPrice()
        {
            string gdPrice = sqlWorker.SelectDataFromDB("SELECT Price FROM Goods WHERE GoodID = " + goodID);

            double goodPrice = Convert.ToDouble(gdPrice);

            double newgoodPrice = goodPrice;

                string disAmount = sqlWorker.SelectDataFromDB("SELECT DiscountAmmount FROM Discounts WHERE GoodID = " + goodID);

                if(disAmount != "")
                {
                    double discount = Convert.ToDouble(disAmount);

                    newgoodPrice = Math.Round(goodPrice - goodPrice * (discount / 100),2);
                }

            return newgoodPrice;
        }
        public string GetGoodName()
        {
            Good good = applicationDbContext.Goods.Find(goodID);
            return good.Name;
        }
        public string GetGoodImage()
        {
            Good good = applicationDbContext.Goods.Find(goodID);
            string imageContainerId = sqlWorker.SelectDataFromDB("SELECT Url FROM ImageContainers WHERE GoodID = " + good.GoodID);
            return imageContainerId;
        }
        public double GetGoodCost()
        {
            Good good = applicationDbContext.Goods.Find(goodID);
            return good.Price;
        }
    }
}