using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlutechShopDiploma.Models.Abstract
{
    public interface IUserMessageRepository
    {
        IEnumerable<UserMessage> UserMessages { get; }
        void CreateMessage(UserMessage message);
    }
}