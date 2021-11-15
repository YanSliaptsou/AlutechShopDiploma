using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using AlutechShopDiploma.Services;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFShippingDetailRepository : IShippingDetailRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<ShippingDetail> ShippingDetails
        {
            get { return context.ShippingDetails; }
        }

        public void CreateShippingDetail(ShippingDetail shippingDetail)
        {
            OrderWorker orderWorker = new OrderWorker();
            UsersWorker usersWorker = new UsersWorker(HttpContext.Current.User.Identity.Name);
            context.ShippingDetails.Add(
                new ShippingDetail
                {
                    ContactMail = shippingDetail.ContactMail,
                    ContactName = shippingDetail.ContactName,
                    ContactPhone = shippingDetail.ContactPhone,
                    DateTime = DateTime.Now,
                    DeliveryAdress = shippingDetail.DeliveryAdress,
                    UserMessage = shippingDetail.UserMessage,
                    OrderId = orderWorker.DefineOrderID(),
                    UserId = usersWorker.GetUserID()
                });
            context.SaveChanges();
        }
    }
}