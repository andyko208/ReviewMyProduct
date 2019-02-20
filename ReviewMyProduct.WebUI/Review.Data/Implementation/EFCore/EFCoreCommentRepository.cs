using Review.Data.Context;
using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreCommentRepository : ICommentRepository
    {
        public Comment Create(Comment newComment)
        {
            using (var context = new ReviewDbContext())
            {
                context.Comments.Add(newComment);
                context.SaveChanges();

                return newComment; 
            }
        }

        public bool DeleteById(int commentId)
        {
            using (var context = new ReviewDbContext())
            {
                var commentToBeDeleted = GetById(commentId);
                context.Remove(commentToBeDeleted);
                context.SaveChanges();
            }
            if (GetById(commentId) == null)
                return true;
            return false;
        }

        public Comment GetById(int commentId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Comments.Single(c => c.Id == commentId);
            }
        }

        public ICollection<Comment> GetByUserId(int userId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Comments
                    .Where(c => c.UserId == userId)
                    .ToList();
            }
        }

        public Comment Update(Comment updatedComment)
        {
            using (var context = new ReviewDbContext())
            {
                var existingComment = GetById(updatedComment.Id);


                context.Entry(existingComment).CurrentValues.SetValues(updatedComment);
                context.SaveChanges();

                return existingComment;
            }
        }
    }
}
