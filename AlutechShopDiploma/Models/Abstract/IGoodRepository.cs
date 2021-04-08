using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IGoodRepository
    {
        IEnumerable<Good> Goods { get; }
        void EditGood(Good good);
        void CreateGood(Good good);
        void DeleteGood(int goodId);
    }
}
