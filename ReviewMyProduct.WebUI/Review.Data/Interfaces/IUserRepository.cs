using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Interfaces
{
    public interface IUserRepository
    {
        // Read
        User GetById(int userId);

        // Create
        User Create(User newUser);

        // Update
        User Update(User updatedUser);

        // Delete
        bool DeleteById(int userId);
    }
}
