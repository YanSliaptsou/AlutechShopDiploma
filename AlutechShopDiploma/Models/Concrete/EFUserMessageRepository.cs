using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AlutechShopDiploma.SQL;
using System;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFUserMessageRepository : IUserMessageRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");

        public IEnumerable<UserMessage> UserMessages 
        { 
            get { return context.UserMessages; }
        }

        public void CreateMessage(UserMessage message)
        {
            
            var name = HttpContext.Current.User.Identity.Name;
            string userID = sqlWorker.SelectDataFromDB("SELECT Id FROM AspNetUsers WHERE UserName = '" + name + "'");
            context.UserMessages.Add(
                new UserMessage
                {
                    UserId = userID,
                    ContactMail = message.ContactMail,
                    ContactName = message.ContactName,
                    ContactPhone = message.ContactPhone,
                    MessageText = message.MessageText,
                    MessageTopic = message.MessageTopic,
                    DateTime = DateTime.Now
                });
            context.SaveChanges();
        }
    }
}