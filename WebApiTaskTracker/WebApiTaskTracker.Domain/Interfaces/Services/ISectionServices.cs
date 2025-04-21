using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Services;
/// <summary>
/// Сервис для работы с секциями
/// </summary>
public interface ISectionServices
{
    /// <summary>
    /// Получить все секции
    /// </summary>
    /// <returns></returns>
    Task<List<Section>> GetAllSectionsAsync();
    /// <summary>
    /// Получить секции доски
    /// </summary>
    /// <param name="boardId">id доски</param>
    /// <returns>Список секций</returns>
    Task<List<Section>> GetSectionBoard(Guid boardId);
    /// <summary>
    /// Получить секцию по id
    /// </summary>
    /// <param name="sectionId"></param>
    /// <returns></returns>
    Task<Section> GetSectionByIdAsync(Guid sectionId);
    /// <summary>
    /// Создать новую секцию на доске
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="position"></param>
    /// <param name="boardId"></param>
    /// <returns></returns>
    Task<Section> AddSectionAsync(string name, string description, int position, Guid boardId);
    /*Task<Section> UpdateSectionAsync(Section section);*/
    /// <summary>
    /// Удалить секцию по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteSectionAsync(Guid id);
}