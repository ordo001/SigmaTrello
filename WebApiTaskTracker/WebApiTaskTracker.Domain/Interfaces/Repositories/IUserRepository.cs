using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс для работы с объектами пользователей
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetByIdAsync(Guid id);
        /// <summary>
        /// Получить пользователя по Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetByEmailAsync(string email);
        /// <summary>
        /// Получить пользователя по Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<User?> GetByLoginAsync(string login);
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsersAsync();
        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUserAsync(User user);
        //Task<bool> DeleteUserByIdAsync(int id);
        //Task<bool> DeleteUserByLoginAsync(string login);
        
    }
}
