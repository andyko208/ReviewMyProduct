using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Review.Data.Implementation.Mock
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>();

        public User Create(User newUser)
        {
            newUser.Id = Users.OrderByDescending(u => u.Id).Single().Id + 1;
            Users.Add(newUser);

            return newUser;
        }

        public bool DeleteById(int userId)
        {
            var user = GetById(userId);
            Users.Remove(user);

            return true;
        }

        //public ICollection<User> GetByCommentId(int commentId)
        //{
        //    return Users.FindAll(u => u.CommentId == commentId);
        //}

        public User GetById(int userId)
        {
            return Users.Single(u => u.Id == userId);
        }

        public User Update(User updatedUser)
        {
            DeleteById(updatedUser.Id);
            Users.Add(updatedUser);

            return updatedUser;
        }
    }
}
