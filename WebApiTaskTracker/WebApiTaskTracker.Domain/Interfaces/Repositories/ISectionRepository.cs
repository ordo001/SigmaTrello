using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories;
/// <summary>
/// Репозиторий для работы с секциями
/// </summary>
public interface ISectionRepository
{
    /// <summary>
    /// Обновить секцию
    /// </summary>
    /// <param name="section"></param>
    /// <param name="newPosition"></param>
    /// <returns></returns>
    Task UpdateSection(Section section);
    /// <summary>
    /// Получить все секции доски
    /// </summary>
    /// <param name="idBoard"></param>
    /// <returns></returns>
    Task<List<Section>> GetBoardSectionWithCards(Guid boardId);
    /// <summary>
    /// Добавить новую секцию в доску
    /// </summary>
    /// <returns></returns>
    Task<Section> AddSection(Guid boardId, string name, int position);
    /// <summary>
    /// Удалить секцию
    /// </summary>
    /// <param name="section"></param>
    /// <returns></returns>
    Task RemoveSection(Section section);
    /// <summary>
    /// Получить секцию по id
    /// </summary>
    /// <param name="sectionId"></param>
    /// <returns></returns>
    Task<Section> GetSectionById(Guid sectionId);
}