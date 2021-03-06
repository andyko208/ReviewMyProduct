﻿using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.Mock
{
    public class MockCommentRepository : ICommentRepository
    {
        private List<Comment> Comments = new List<Comment>();

        public Comment Create(Comment newComment)
        {
            newComment.Id = Comments.OrderByDescending(c => c.Id).Single().Id + 1;
            Comments.Add(newComment);

            return newComment;
        }

        public void DeleteById(int commentId)
        {
            var comment = GetById(commentId);
            Comments.Remove(comment);

        }

        public Comment GetById(int commentId)
        {
            return Comments.Single(c => c.Id == commentId);
        }

        public ICollection<Comment> GetByProductId(int productId)
        {
            return Comments.FindAll(c => c.productId == productId);
        }

        public ICollection<Comment> GetByUserId(string userId)
        {
            return Comments.FindAll(c => c.UserId == userId);
        }

        public Comment Update(Comment updatedComment)
        {
            DeleteById(updatedComment.Id); 
            Comments.Add(updatedComment);

            return updatedComment;
        }
    }
}
