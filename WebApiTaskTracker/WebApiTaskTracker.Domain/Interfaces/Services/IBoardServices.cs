using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Services
{
    public interface IBoardServices
    {
        /// <summary>
        /// Получить все доски пользователя
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<List<Board>> GetUserBoards(Guid idUser);
        /// <summary>
        /// Получить все доски
        /// </summary>
        /// <returns></returns>
        Task<List<Board>> GetBoards();
        /// <summary>
        /// Создать новую доску без пользователей
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<Guid?> AddBoard(string name, string description, Guid idOwner);
        /// <summary>
        /// Создать новую доску с пользователями
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        Task<Guid?> AddBoardWithUsers(string name, string description, Guid idOwner, List<Guid> usersId);
        /// <summary>
        /// Добавление пользователя в доску
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="IdBoard"></param>
        /// <returns></returns>
        Task AddUserInBoard(Guid idUser, Guid idBoard, string role);
    }
}
