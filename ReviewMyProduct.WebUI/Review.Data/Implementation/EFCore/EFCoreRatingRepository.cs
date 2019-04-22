using Review.Data.Context;
using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreRatingRepository : IRatingRepository
    {
        public Rating Create(Rating newRating)
        {
            using (var context = new ReviewDbContext())
            {
                context.Ratings.Add(newRating);
                context.SaveChanges();

                return newRating;
            }
        }

        public ICollection<Rating> GetByCommentId(int commentId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Ratings
                    .Where(r => r.CommentId == commentId)
                    .ToList();
            }
        }

        public Rating GetById(int ratingId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Ratings.Single(r => r.Id == ratingId);
            }
        }

        public ICollection<Rating> GetByUserId(string userId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Ratings
                    .Where(r => r.UserId == userId)
                    .ToList();
            }
        }
    }
}
