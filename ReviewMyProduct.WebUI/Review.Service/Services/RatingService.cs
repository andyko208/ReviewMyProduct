using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface IRatingService
    {
        void Create(Rating newRating);
        Rating GetById(int ratingId);
        ICollection<Rating> GetByUserId(string userId);
        ICollection<Rating> GetByCommentId(int commentId);
    }
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public void Create(Rating newRating)
        {
            _ratingRepository.Create(newRating);
        }

        public ICollection<Rating> GetByCommentId(int commentId)
        {
            return _ratingRepository.GetByCommentId(commentId);
        }

        public Rating GetById(int ratingId)
        {
            return _ratingRepository.GetById(ratingId);
        }

        public ICollection<Rating> GetByUserId(string userId)
        {
            return _ratingRepository.GetByUserId(userId);
        }
    }
}
