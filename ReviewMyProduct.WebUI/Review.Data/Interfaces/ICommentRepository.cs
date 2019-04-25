using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface ICommentRepository
    {
        // Read
        Comment GetById(int commentId);
        ICollection<Comment> GetByUserId(string userId);
        ICollection<Comment> GetByProductId(int productId);

        // Create
        Comment Create(Comment newComment);

        // Update
        Comment Update(Comment updatedComment);

        // Delete
        void DeleteById(int commentId);
    }
}
