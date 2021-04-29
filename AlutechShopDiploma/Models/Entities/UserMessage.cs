using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class UserMessage
    {
        private int userMessageID;
        private string userId;
        private string contactName;
        private string contactPhone;
        private string contactMail;
        private string messageTopic;
        private string messageText;
        private DateTime dateTime;

        public int UserMessageID { get => userMessageID; set => userMessageID = value; }
        public string UserId { get => userId; set => userId = value; }
        public string MessageTopic { get => messageTopic; set => messageTopic = value; }
        public string MessageText { get => messageText; set => messageText = value; }
        [Required(ErrorMessage = "Введите имя/Enter name")]
        public string ContactName { get => contactName; set => contactName = value; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите контактный номер телефона/Enter phone number")]
        public string ContactPhone { get => contactPhone; set => contactPhone = value; }

        [DataType(DataType.EmailAddress)]
        public string ContactMail { get => contactMail; set => contactMail = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
    }
}