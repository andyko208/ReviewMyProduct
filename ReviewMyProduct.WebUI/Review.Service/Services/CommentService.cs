using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface ICommentService
    {
        Comment GetById(int commentId);
        ICollection<Comment> GetByUserId(string userId);
        ICollection<Comment> GetByProductId(int productId);
        void Create(Comment newComment);
        void Update(Comment updatedComment);
        void DeleteById(int commentId);
    }
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(Comment newComment)
        {
            _commentRepository.Create(newComment);
        }

        public void DeleteById(int commentId)
        {
            _commentRepository.DeleteById(commentId);
        }

        public Comment GetById(int commentId)
        {
            return _commentRepository.GetById(commentId);
        }

        public ICollection<Comment> GetByProductId(int productId)
        {
            return _commentRepository.GetByProductId(productId);
        }

        public ICollection<Comment> GetByUserId(string userId)
        {
            return _commentRepository.GetByUserId(userId);
        }

        public void Update(Comment updatedComment)
        {
            _commentRepository.Update(updatedComment);
        }
    }
}
