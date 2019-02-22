using Review.Data.Context;
using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreUserRepository : IUserRepository
    {
        public User Create(User newUser)
        {
            using (var context = new ReviewDbContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();

                return newUser;
            }
        }

        public bool DeleteById(int userId)
        {
            using (var context = new ReviewDbContext())
            {
                var userToBeDeleted = GetById(userId);
                context.Remove(userToBeDeleted);
                context.SaveChanges();
            }
            if (GetById(userId) == null)
                return true;
            return false;
        }

        //public ICollection<User> GetByCommentId(int commentId)
        //{
        //    using (var context = new ReviewDbContext())
        //    {
        //        return context.Users
        //            .Where(u => u.CommentId == commentId)
        //            .ToList();
        //    }
        //}

        public User GetById(int userId)
        {
            using (var context = new ReviewDbContext())
            {
                return context.Users.Single(u => u.Id == userId);
            }
        }

        public User Update(User updatedUser)
        {
            using (var context = new ReviewDbContext())
            {
                var existingUser = GetById(updatedUser.Id);

                context.Entry(existingUser).CurrentValues.SetValues(updatedUser);
                context.SaveChanges();

                return existingUser;
            }
        }
    }
}
