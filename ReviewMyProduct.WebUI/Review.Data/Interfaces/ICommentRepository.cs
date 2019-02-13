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
        ICollection<Comment> GetCommentsByUserId(int userId);

        // Create
        Comment Create(Comment newComment);

        // Update
        Comment Update(Comment updatedComment);

        // Delete
        bool DeleteById(int commentId);
    }
}
