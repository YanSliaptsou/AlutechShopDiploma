using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Services;

namespace AlutechShopDiploma.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public int orderId 
        {
            get
            {
                OrderWorker orderWorker = new OrderWorker();
                return orderWorker.DefineOrderID();
            }
        }
        public double userBalance { get; set; }

        public int goodAmmount { get; set; }

    }
}