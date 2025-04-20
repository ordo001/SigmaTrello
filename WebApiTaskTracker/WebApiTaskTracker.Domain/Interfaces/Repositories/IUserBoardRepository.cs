using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями и досками
    /// </summary>
    public interface IUserBoardRepository
    {
        /// <summary>
        /// Получить доски, к которым принадлежит пользователь
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Board>> GetBoardsByUserIdAsync(Guid userId);
        /// <summary>
        /// Получить пользователей определенной доски
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        Task<List<User>> GetUsersByBoardIdAsync(Guid boardId);
        /// <summary>
        /// Добавить пользователя в доску
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="boardId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        Task AddUserToBoardAsync(Guid userId, Guid boardId, string role);
        /// <summary>
        /// Добавить список пользователей в доску
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        Task AddUserRangeToBoardAsync(Guid boardId, List<Domain.Models.UserBoard> userBoard);
        /// <summary>
        /// Удалить пользователя из доски
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="boardId"></param>
        /// <returns></returns>
        Task RemoveUserFromBoardAsync(Guid userId, Guid boardId);
        /// <summary>
        /// Обновить роль пользователя определённой доски
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="boardId">Id доски</param>
        /// <param name="newRole">Новая роль</param>
        /// <returns></returns>
        Task UpdateUserRoleAsync(Guid userId, Guid boardId, string newRole);
    }
}
