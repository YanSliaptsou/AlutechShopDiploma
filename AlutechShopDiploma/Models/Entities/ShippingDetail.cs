using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AlutechShopDiploma.Models.Entities
{
    public class ShippingDetail
    {
        private int shippingDetailID;
        private string contactName;
        private string contactPhone;
        private string contactMail;
        private string deliveryAdress;
        private string userMessage;
        private DateTime dateTime;
        private int orderId;
        private string userId;

        public int ShippingDetailID { get => shippingDetailID; set => shippingDetailID = value; }

        [Required(ErrorMessage = "Введите своё имя/Enter your name")]
        public string ContactName { get => contactName; set => contactName = value; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите своЙ номер телефона/Enter your phone number")]
        public string ContactPhone { get => contactPhone; set => contactPhone = value; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите своЙ е-мэйл /Enter your E-mail")]
        public string ContactMail { get => contactMail; set => contactMail = value; }

        public string DeliveryAdress { get => deliveryAdress; set => deliveryAdress = value; }
        public string UserMessage { get => userMessage; set => userMessage = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public string UserId { get => userId; set => userId = value; }
    }
}