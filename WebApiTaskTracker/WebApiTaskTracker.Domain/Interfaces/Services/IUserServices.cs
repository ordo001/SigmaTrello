using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task<Guid?> AddUserAsync(string login, string password, string name, string email);
        //Task<List<Domain.Models.User>> GetUsersAsync();
    }
}
