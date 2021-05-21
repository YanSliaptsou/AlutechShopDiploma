using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.ViewModels
{
    public class UserBalanceViewModel
    {
        public IEnumerable<Order> orders { get; set; }
        public double userBalance { get; set; }
    }
}