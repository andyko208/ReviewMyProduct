using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface IRatingRepository
    {
        Rating GetById(int ratingId);
        ICollection<Rating> GetByUserId(string userId);
        ICollection<Rating> GetByCommentId(int commentId);
    }
}
