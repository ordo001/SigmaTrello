using WebApiTaskTracker.Application.Exceptions;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Application.Servises;

public class SectionService(ISectionRepository sectionRepository, IBoardRepository boardRepository) : ISectionServices
{
    public Task<List<Section>> GetAllSectionsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Section> GetSectionByIdAsync(Guid sectionId)
    {
        try
        {
            return await sectionRepository.GetSectionById(sectionId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Section>> GetSectionWithCardsBoardAsync(Guid boardId)
    {
        var result = await boardRepository.GetByIdAsync(boardId);
        if (result is null)
        {
            throw new EntityNotFoundException<Board>(boardId);
        }
        
        try
        {
            var sections = await sectionRepository.GetBoardSectionWithCards(boardId);
            return sections.OrderBy(s => s.Position).ToList();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Section> AddSectionAsync(string name, int position, Guid boardId)
    {
        var result = await boardRepository.GetByIdAsync(boardId);
        if (result is null)
            throw new EntityNotFoundException<Board>(boardId);
        
        try
        {
            return await sectionRepository.AddSection(boardId, name, position);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task DeleteSectionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePositionSectionAsync(Guid sectionId, int newPosition)
    {
        var section = await sectionRepository.GetSectionById(sectionId);
        if (section is null)
            throw new EntityNotFoundException<Section>(sectionId);
        try
        {
            section.Position = newPosition;
            await sectionRepository.UpdateSection(section);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}