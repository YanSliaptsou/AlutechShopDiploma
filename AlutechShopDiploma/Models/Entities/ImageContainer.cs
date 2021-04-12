using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class ImageContainer
    {
        private int imageContainerID;
        private int goodID;
        private string url;

        public int ImageContainerID { get => imageContainerID; set => imageContainerID = value; }
        public int GoodID { get => goodID; set => goodID = value; }
        public string Url { get => url; set => url = value; }
    }
}