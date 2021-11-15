using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.ViewModels
{
    public class GoodViewModel
    {
        public IEnumerable<Good> Goods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentSubcategory { get; set; }
        public SortState SortState { get; set; }
    }
}