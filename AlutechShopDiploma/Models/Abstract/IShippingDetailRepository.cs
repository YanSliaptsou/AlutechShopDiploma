using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlutechShopDiploma.Models.Entities;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IShippingDetailRepository
    {
        IEnumerable<ShippingDetail> ShippingDetails { get; }
        void CreateShippingDetail(ShippingDetail shippingDetail);
    }
}
