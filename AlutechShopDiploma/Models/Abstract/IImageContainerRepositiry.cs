using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IImageContainerRepositiry
    {
        IEnumerable<ImageContainer> Images { get; }
        void CreateImage(ImageContainer image);
        void EditImage(ImageContainer image);
        void DeleteImage(int imageId);
    }
}
