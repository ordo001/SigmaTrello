using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories;
/// <summary>
/// Репозиторий для работы с секциями
/// </summary>
public interface ISectionRepository
{
    /// <summary>
    /// Обновить позицию секций
    /// </summary>
    /// <param name="sectionId"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    //TODO: СДЕЛАТЬ ПРАВИЛЬНО БЛЯ, ЧТОБЫ МОЖНО БЫЛО ИЗМЕНИТЬ ПОЗИЦИЮ ВСЕХ СЕКЦИЙ НА ДОСКЕ
    Task<Section> UpdatePositonSections(Guid sectionId, int position);
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