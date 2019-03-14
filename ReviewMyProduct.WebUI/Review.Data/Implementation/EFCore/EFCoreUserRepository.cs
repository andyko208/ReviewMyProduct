using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Implementation.EFCore
{
    public class EFCoreUserRepository : IUserRepository
    {
        public User Create(User newUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public User Update(User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
