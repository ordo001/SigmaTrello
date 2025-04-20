using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий для работы с объектами досок
    /// </summary>
    public interface IBoardRepository
    {
        /// <summary>
        /// Асинхронно возвращает доску по её идентификатору.
        /// Если доска не найдена, выбрасывает исключение.
        /// </summary>
        /// <param name="id">Идентификатор доски, который нужно найти.</param>
        /// <returns>Объект <see cref="Board"/> или null, если доска не найдена.</returns>
        Task<Board?> GetByIdAsync(Guid id);

        /// Асинхронно возвращает список всех досок из базы данных.
        /// <returns>
        /// Список экземпляров досок типа List<Board>.
        /// </returns>
        Task<List<Board>> GetBoardsAsync();

        /// Асинхронно добавляет новую доску в хранилище данных.
        /// <param name="board">Модель доски, которая будет добавлена.</param>
        /// <returns>Возвращает задачу, представляющую асинхронную операцию.</returns>
        Task AddBoardAsync(Board board);

        /// <summary>
        /// Удаляет доску с указанным идентификатором из хранилища.
        /// </summary>
        /// <param name="id">Идентификатор доски, которую необходимо удалить.</param>
        /// <returns>Асинхронная операция Task.</returns>
        /// <exception cref="Exception">Выбрасывается, если доска с указанным идентификатором не найдена.</exception>
        Task RemoveBoardAsync(Guid id);
    }
}
