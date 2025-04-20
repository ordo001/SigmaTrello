using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий пользователей.
    /// Обеспечивает методы для взаимодействия с данными пользователей в хранилище.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Асинхронно получает пользователя по указанному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя.</param>
        /// <returns>Возвращает объект пользователя, если пользователь найден; иначе null.</returns>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>
        /// Асинхронно получает пользователя по его адресу электронной почты.
        /// </summary>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        /// <returns>Объект пользователя типа <see cref="User"/>, если пользователь найден, или null, если пользователь не найден.</returns
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Асинхронно получает пользователя по указанному логину.
        /// </summary>
        /// <param name="login">Логин пользователя для поиска.</param>
        /// <returns>Пользователя типа <see cref="User"/>, если он найден, или null, если пользователь с таким логином не существует.</returns>
        Task<User?> GetByLoginAsync(string login);

        /// Асинхронно получает список всех пользователей из базы данных.
        /// <returns>
        /// Возвращает список объектов типа `User`.
        /// </returns>
        Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Добавляет нового пользователя в систему асинхронно.
        /// </summary>
        /// <param name="user">Объект типа User, представляющий добавляемого пользователя.</param>
        /// <returns>Задача, представляющая асинхронную операцию добавления пользователя.</returns>
        Task AddUserAsync(User user);
    }
}
