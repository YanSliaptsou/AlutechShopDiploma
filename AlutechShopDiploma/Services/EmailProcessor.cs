using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

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
    }
}