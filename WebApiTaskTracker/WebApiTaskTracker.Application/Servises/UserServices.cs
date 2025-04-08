using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Application.Servises
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public UserServices(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<Guid?> AddUserAsync(string login, string password, string name, string email)
        {
            var result = await _userRepository.GetByLoginAsync(login);
            if (result is not null)
                throw new Exception(message: "Логин занят");
            
            try
            {
                var passwordHash = _passwordHasher.HashPassword(password);
                
                var newUser = new User(login, passwordHash, name, email);
                await _userRepository.AddUserAsync(newUser);
                return newUser.Id;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}

