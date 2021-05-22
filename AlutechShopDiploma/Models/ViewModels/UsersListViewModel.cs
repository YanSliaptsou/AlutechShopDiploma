using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}