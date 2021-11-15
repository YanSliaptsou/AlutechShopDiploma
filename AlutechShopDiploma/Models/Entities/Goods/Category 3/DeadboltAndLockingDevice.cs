using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities.Goods.Category_3
{
    public class DeadboltAndLockingDevice
    {
        private int deadboltAndLockingDeviceID;
        private double weight;
        private string deliveryRate; //норма поставки

        public int DeadboltAndLockingDeviceID { get => deadboltAndLockingDeviceID; set => deadboltAndLockingDeviceID = value; }
        public double Weight { get => weight; set => weight = value; }
        public string DeliveryRate { get => deliveryRate; set => deliveryRate = value; }
    }
}