using Microsoft.EntityFrameworkCore;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Infrastructure.Data;
using WebApiTaskTracker.Domain.Models;
using WebApiTaskTracker.Infrastructure.Mapping;
using Section = WebApiTaskTracker.Domain.Models.Section;
using WebApiTaskTracker.Application.Exceptions;

namespace WebApiTaskTracker.Infrastructure.Repositories;

public class SectionRepository(TaskTrackerContext taskTrackerContext) : ISectionRepository
{
    public async Task UpdateSection(Section section)
    {
        taskTrackerContext.Sections.Update(section.ToEntity());
        await taskTrackerContext.SaveChangesAsync();
    }

    public async Task<List<Domain.Models.Section>> GetBoardSectionWithCards(Guid boardId)
    {
        var sections = await taskTrackerContext.Sections
            .AsNoTracking()
            .Include(s => s.Cards)
            .Where(s => s.IdBoard == boardId)
            .ToListAsync();

        return sections.Select(s => s.ToDomain()).ToList();
    }

    public async Task<Domain.Models.Section> AddSection(Guid boardId, string name, int position)
    {
        var section = new Data.Section
        {
            Id = Guid.NewGuid(),
            IdBoard = boardId,
            Name = name,
            Position = position
        };
        await taskTrackerContext.Sections.AddAsync(section);
        await taskTrackerContext.SaveChangesAsync();

        return section.ToDomain();
    }

    public async Task RemoveSection(Section section)
    {
        taskTrackerContext.Sections.Remove(section.ToEntity());
        await taskTrackerContext.SaveChangesAsync();
    }

    public async Task<Section> GetSectionById(Guid sectionId)
    {
        var section = await taskTrackerContext.Sections
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == sectionId);
        if (section is not null)
        {
            return section.ToDomain();
        }

        throw new EntityNotFoundException<Section>(sectionId);
    }
}