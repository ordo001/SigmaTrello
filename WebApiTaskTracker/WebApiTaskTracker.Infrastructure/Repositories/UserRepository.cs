using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Models;
using WebApiTaskTracker.Infrastructure.Data;
using WebApiTaskTracker.Infrastructure.Mapping;

namespace WebApiTaskTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskTrackerContext _taskTrackerContext;
        public UserRepository(TaskTrackerContext taskTrackerContext)
        {
            _taskTrackerContext = taskTrackerContext;
        }

        public async Task AddUserAsync(Domain.Models.User user)
        {
            await _taskTrackerContext.Users.AddAsync(user.ToEntity());
            await _taskTrackerContext.SaveChangesAsync();
        }

        public async Task<Domain.Models.User?> GetByEmailAsync(string email)
        {
            var user = await _taskTrackerContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null;
            }
            return user.ToDomain();
        }

        public async Task<Domain.Models.User?> GetByIdAsync(Guid id)
        {
            var user = await _taskTrackerContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user.ToDomain();
        }

        public async Task<Domain.Models.User?> GetByLoginAsync(string login)
        {
            var user = await _taskTrackerContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
            {
                return null;
            }
            return user.ToDomain();
        }

        public async Task<List<Domain.Models.User>> GetUsersAsync()
        {
            var userList = await _taskTrackerContext.Users.AsNoTracking().ToListAsync();
            return userList.Select(u => u.ToDomain()).ToList();
        }
    }
}
