using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface IRatingRepository
    {
        Rating Create(Rating newRating);
        Rating GetById(int ratingId);
        ICollection<Rating> GetByUserId(string userId);
        ICollection<Rating> GetByCommentId(int commentId);
        ICollection<Rating> GetByCommentUserId(int commentId, string userId);
    }
}
