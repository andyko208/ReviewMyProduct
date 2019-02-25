using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Review.Data.Implementation.Mock
{

    public class MockRatingRepository : IRatingRepository
    {
        private List<Rating> Ratings = new List<Rating>();

        public ICollection<Rating> GetByCommentId(int commentId)
        {
            return Ratings.FindAll(r => r.CommentId == commentId);
        }

        public Rating GetById(int ratingId)
        {
            return Ratings.Single(r => r.Id == ratingId);
        }

        public ICollection<Rating> GetByUserId(string userId)
        {
            return Ratings.FindAll(r => r.UserId == userId);
        }
    }
}
