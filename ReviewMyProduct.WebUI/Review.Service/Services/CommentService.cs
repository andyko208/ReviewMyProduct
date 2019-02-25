﻿using Review.Data.Interfaces;
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
    }
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment GetById(int commentId)
        {
            return _commentRepository.GetById(commentId);
        }

        public ICollection<Comment> GetByUserId(string userId)
        {
            return _commentRepository.GetByUserId(userId);
        }
    }
}
