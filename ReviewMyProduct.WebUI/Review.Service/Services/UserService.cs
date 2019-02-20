using Review.Data.Interfaces;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Service.Services
{
    public interface IUserService
    {
        User GetById(int userId);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository
        }
        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}
