using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Comments { get; }
        void EditComment(Comment comment);
        void CreateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}
