using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.SQL;

namespace AlutechShopDiploma.Controllers
{
    public class CommnetController : Controller
    {
        ICommentRepository repository;

        public CommnetController(ICommentRepository rep)
        {
            repository = rep;
        }

    }
}