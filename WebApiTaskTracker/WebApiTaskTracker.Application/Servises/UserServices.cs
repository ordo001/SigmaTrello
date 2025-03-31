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
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid?> AddUserAsync(string login, string password, string name, string email)
        {
            try
            {
                var newUser = new User(login, password, name, email);
                await _userRepository.AddUserAsync(newUser);
                return newUser.Id;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
