using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFImageContainerRepositiry : IImageContainerRepositiry
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<ImageContainer> Images
        {
            get { return context.ImageContainers; }
        }

        public void CreateImage(ImageContainer image)
        {
            context.ImageContainers.Add(new ImageContainer
            {
                GoodID = image.GoodID,
                Url = image.Url
            });
            context.SaveChanges();
        }

        public void DeleteImage(int imageId)
        {
            context.ImageContainers.Remove(context.ImageContainers.FirstOrDefault(x => x.ImageContainerID == imageId));
            context.SaveChanges();
        }

        public void EditImage(ImageContainer image)
        {
            ImageContainer img = context.ImageContainers.Find(image.ImageContainerID);

            img.Url = image.Url;
            context.SaveChanges();
        }
    }
}