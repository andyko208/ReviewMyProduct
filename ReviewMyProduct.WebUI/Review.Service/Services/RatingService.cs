using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface IRatingService
    {
        Rating GetById(int ratingId);
        ICollection<Rating> GetByUserId(int userId);
        ICollection<Rating> GetByCommentId(int commentId);
    }
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public ICollection<Rating> GetByCommentId(int commentId)
        {
            return _ratingRepository.GetByCommentId(commentId);
        }

        public Rating GetById(int ratingId)
        {
            return _ratingRepository.GetById(ratingId);
        }

        public ICollection<Rating> GetByUserId(int userId)
        {
            return _ratingRepository.GetByUserId(userId);
        }
    }
}
