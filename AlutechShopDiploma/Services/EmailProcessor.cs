using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using AlutechShopDiploma.Services;
using Microsoft.AspNet;
using System.Web;
using System.Web.Routing;



namespace AlutechShopDiploma.Models.Concrete
{

    public class EmailSettings
    {
        public string MailToAdress = "";
        public string MailFromAddress = "yansleptsov4@gmail.com";
        public bool UseSsl = true;
        public string Username = "yansleptsov4@gmail.com";
        public string Password = "SLEPTSOVYAN1999";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }

    public class EmailProcessor
    {
        private EmailSettings emailSettings;

        public EmailProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessUserMessage(UserMessage userMessage)
        {
            using(var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder messageBodyToAdmin = new StringBuilder();

                messageBodyToAdmin.AppendLine("Поступило новое сообщение от клиента " + userMessage.ContactName);
                messageBodyToAdmin.AppendLine("");
                messageBodyToAdmin.AppendLine("Тема сообщения: " + userMessage.MessageTopic);
                messageBodyToAdmin.AppendLine("Текст сообщения: " + userMessage.MessageText);
                messageBodyToAdmin.AppendLine("");
                messageBodyToAdmin.AppendLine("Контактная информация:");
                messageBodyToAdmin.AppendLine("Электронный адрес: " + userMessage.ContactMail);
                messageBodyToAdmin.AppendLine("Контактный телефон: "+ userMessage.ContactPhone);

                MailMessage messageToAdmin = new MailMessage(
                    emailSettings.MailFromAddress,
                    "yansleptsov4@gmail.com",
                    "Новое сообщение от клиента",
                    messageBodyToAdmin.ToString()
                );

                StringBuilder messageBodyToClient = new StringBuilder();
                messageBodyToClient.AppendLine("Уважыемый " + userMessage.ContactName + "!");
                messageBodyToClient.AppendLine("Ваше сообщение принято администратором. В ближайшее время с вами свяжутся.");
                messageBodyToClient.AppendLine("Текст сообщения: " + userMessage.MessageText);


                MailMessage messageToClient = new MailMessage(
                    emailSettings.MailFromAddress,
                    userMessage.ContactMail,
                    "Спасибо за ваше сообщение ",
                    messageBodyToClient.ToString()
                    );

                smptClient.Send(messageToAdmin);
                smptClient.Send(messageToClient);
            }
        }

        public void ProcessUserOrder(ShippingDetail detail, double bonusAmmount)
        {
            OrderWorker orderWorker = new OrderWorker();
            UsersWorker usersWorker = new UsersWorker(HttpContext.Current.User.Identity.Name);
            string _userId = usersWorker.GetUserID();
            int _orderId = orderWorker.DefineOrderID();

            List<string> items = orderWorker.GetOrderDetails(Enums.OrderDetail.Name);
            List<string> pricesPerGoodItems = orderWorker.GetOrderDetails(Enums.OrderDetail.PricePerGoodItem);
            List<string> ammounts = orderWorker.GetOrderDetails(Enums.OrderDetail.AmountOfItems);
            List<string> pricesPerOrderItems = orderWorker.GetOrderDetails(Enums.OrderDetail.PricePerOrderItem);

            double totalOrderPrice = orderWorker.GetOrderPrice();
            int ammountOfitems = orderWorker.DefineOrderItemsCountInOrder();

            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var confirmBonusUrl = urlHelper.Action("ConfirmPurchase", "Purchase", new {userId = _userId, orderId = _orderId },protocol:HttpContext.Current.Request.Url.Scheme);

            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                //------------------------------------------------------------------------------------------
                StringBuilder messageBodyToAdmin = new StringBuilder();

                messageBodyToAdmin.AppendLine("Поступил новый заказ от клиента. Номер заказа: " + orderWorker.DefineOrderID());
                messageBodyToAdmin.AppendLine("");

                messageBodyToAdmin.AppendLine("Детали заказа:");
                for(int i = 0; i < ammountOfitems;i++)
                {
                    messageBodyToAdmin.AppendLine(i + 1 + ". " + items[i] + " " + pricesPerGoodItems[i] + " р. x " + ammounts[i] + " шт." + " = " + pricesPerOrderItems[i] + " р.");
                }
                messageBodyToAdmin.AppendLine("Итоговая сумма: " + totalOrderPrice.ToString() + " р.");
                messageBodyToAdmin.AppendLine("");
                messageBodyToAdmin.AppendLine("Контактные данные клиента:");
                messageBodyToAdmin.AppendLine("Имя: " + detail.ContactName);
                messageBodyToAdmin.AppendLine("Мобильный телефон: " + detail.ContactPhone);
                messageBodyToAdmin.AppendLine("Электронная почта: " + detail.ContactMail);
                messageBodyToAdmin.AppendLine("Адрес доставки: " + detail.DeliveryAdress);
                messageBodyToAdmin.AppendLine("Комментарий: " + detail.UserMessage);
                messageBodyToAdmin.AppendLine("Дата и время оформления заказа: " + DateTime.Now);
                messageBodyToAdmin.AppendLine("");

                messageBodyToAdmin.AppendLine("Подтвердить покупку здесь: " + confirmBonusUrl);

                MailMessage messageToAdmin = new MailMessage(
                    emailSettings.MailFromAddress,
                    "yansleptsov4@gmail.com",
                    "Новый заказ от клиента",
                    messageBodyToAdmin.ToString()
                );

                smptClient.Send(messageToAdmin);

                //------------------------------------------------------------------------------------------
                StringBuilder messageBodyToClient = new StringBuilder();

                messageBodyToClient.AppendLine("Спасибо за покупку в нашем магазине. Ваш номер заказа: " + orderWorker.DefineOrderID());
                messageBodyToClient.AppendLine("");

                messageBodyToClient.AppendLine("Детали заказа:");
                for (int i = 0; i < ammountOfitems; i++)
                {
                    messageBodyToClient.AppendLine(i + 1 + ". " + items[i] + " " + pricesPerGoodItems[i] + " р. x " + ammounts[i] + " шт." + " = " + pricesPerOrderItems[i] + " р.");
                }
                messageBodyToClient.AppendLine("Итоговая сумма: " + totalOrderPrice.ToString() + " р.");
                messageBodyToClient.AppendLine("");
                messageBodyToClient.AppendLine("Контактные данные клиента:");
                messageBodyToClient.AppendLine("Имя: " + detail.ContactName);
                messageBodyToClient.AppendLine("Мобильный телефон: " + detail.ContactPhone);
                messageBodyToClient.AppendLine("Электронная почта: " + detail.ContactMail);
                messageBodyToClient.AppendLine("Адрес доставки: " + detail.DeliveryAdress);
                messageBodyToClient.AppendLine("Комментарий: " + detail.UserMessage);
                messageBodyToClient.AppendLine("Дата и время оформления заказа: " + DateTime.Now);

                messageBodyToClient.AppendLine("");
                messageBodyToClient.AppendLine("С вами вскоре свяжутся. Ожидайте.");
                messageBodyToClient.AppendLine("");
                messageBodyToClient.AppendLine("Внимание!!!");
                messageBodyToClient.AppendLine("При успешном завершении и оплаты заказа на ваш бонусный счёт будет зачислено " + bonusAmmount + " р., которые вы в любой момент сможете потратить на любой другой заказ.");
                messageBodyToClient.AppendLine("Зачисление денежных средств на ваш бонусный счёт осуществляется только после подтверждения нашим менеджером вашего заказа.");
                messageBodyToClient.AppendLine("После подтверждения заказа нашим менеджером вам на почту, которую вы указывали про оформлении заказа, придёт письмо о зачислении. Если вы его не найдёте, проверьте его в папке 'Спам'.");



                MailMessage messageToClient = new MailMessage(
                    emailSettings.MailFromAddress,
                    detail.ContactMail,
                    "Заказ в AlutechShop",
                    messageBodyToClient.ToString()
                );
                smptClient.Send(messageToClient);
            }
        }

        public void ProcessPurchaseConfrimation(double bonusSum, ShippingDetail detail)
        {
            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                //------------------------------------------------------------------------------------------
                StringBuilder messageBodyToClient = new StringBuilder();

                messageBodyToClient.AppendLine("На ваш бонусный баланс успешно начислена сумма: " + bonusSum + " р.");

                MailMessage messageToClient = new MailMessage(
                    emailSettings.MailFromAddress,
                    detail.ContactMail,
                    "Зачисление бонусного счёта",
                    messageBodyToClient.ToString()
                );
                smptClient.Send(messageToClient);
            }
        }

        public void ProcessAskingToUnbanUser(ApplicationUser user)
        {
            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder messageBodyToClient = new StringBuilder();

                messageBodyToClient.AppendLine("Уважаемый(-ая) " + user.UserName);
                messageBodyToClient.AppendLine("Вы успешно подали запрос на разблокировку вас.");
                messageBodyToClient.AppendLine("Ваша заявка будет рассмотрена в течение некоторого времени. Результат о рассмотрении придёт вам на почту, указанную при регистрации");
                messageBodyToClient.AppendLine("С уважением, админимтрация AlutechShop");
                MailMessage messageToClient = new MailMessage(
                    emailSettings.MailFromAddress,
                    user.Email,
                    "Заявка о разблокировке",
                    messageBodyToClient.ToString()
                );
                smptClient.Send(messageToClient);

                StringBuilder messageBodyToAdmin = new StringBuilder();

                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var confirmBonusUrl = urlHelper.Action("UnbanUser", "Administation", new { userId = user.Id }, protocol: HttpContext.Current.Request.Url.Scheme);

                messageBodyToAdmin.AppendLine("Поступила заяка о разблокировке от клиента " + user.UserName + " Id = " + user.Id);
                messageBodyToAdmin.AppendLine("Разблокировать можно по ссылке: " + confirmBonusUrl);

                MailMessage messageToAdmin = new MailMessage(
                    emailSettings.MailFromAddress,
                    "yansleptsov4@gmail.com",
                    "Заявка о разблокировке",
                    messageBodyToAdmin.ToString()
                );
                smptClient.Send(messageToAdmin);
            }
        }

        public void ProcessInformClientAboutUnban(ApplicationUser user)
        {
            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder messageBodyToClient = new StringBuilder();

                messageBodyToClient.AppendLine("Уважаемый(-ая) " + user.UserName);
                messageBodyToClient.AppendLine("Мы проверили вашу учётную запись.");
                messageBodyToClient.AppendLine("Ваша учётная запись была успешно разблокирована. Теперь вы можете писать комментарии и оценивать наши товары.");
                messageBodyToClient.AppendLine("Приносим извинения за ваше беспокойство.");
                messageBodyToClient.AppendLine("С уважением, админимтрация AlutechShop");

                MailMessage messageToClient = new MailMessage(
                    emailSettings.MailFromAddress,
                    user.Email,
                    "Сообщение о разблокировке",
                    messageBodyToClient.ToString()
                );
                smptClient.Send(messageToClient);
            }
        }
    }
}