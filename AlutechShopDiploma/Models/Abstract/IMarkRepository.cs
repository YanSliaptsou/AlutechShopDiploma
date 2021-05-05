using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IMarkRepository
    {
        IEnumerable<Mark> Marks { get; }
        void CreateMark(Mark mark);
        void DeleteMark(int goodMarkID);
    }
}
