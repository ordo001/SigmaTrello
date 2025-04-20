using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories;
/// <summary>
/// Репозиторий для работы с секциями
/// </summary>
public interface ISectionRepository
{
    /// <summary>
    /// Получить все секции доски
    /// </summary>
    /// <param name="idBoard"></param>
    /// <returns></returns>
    Task<List<Section>> GetBoardSection(Guid boardId);
    /// <summary>
    /// Добавить новую секцию в доску
    /// </summary>
    /// <returns></returns>
    Task<Section> AddSection(Guid boardId, string name, string description, int position);
    /// <summary>
    /// Удалить секцию
    /// </summary>
    /// <param name="boardId"></param>
    /// <returns></returns>
    Task RemoveSection(Guid boardId);
}