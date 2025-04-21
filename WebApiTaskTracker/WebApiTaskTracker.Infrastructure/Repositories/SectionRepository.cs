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
    public Task<Section> UpdatePositonSections(Guid sectionId, int position)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Domain.Models.Section>> GetBoardSection(Guid boardId)
    {
        var sections = await taskTrackerContext.Sections
            .AsNoTracking()
            .Where(s => s.IdBoard == boardId)
            .ToListAsync();

        return sections.Select(s => s.ToDomain()).ToList();
    }

    public async Task<Domain.Models.Section> AddSection(Guid boardId, string name, string description, int position)
    {
        var section = new Data.Section
        {
            Id = Guid.NewGuid(),
            IdBoard = boardId,
            Name = name,
            Description = description,
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
            .FirstOrDefaultAsync(s => s.Id == sectionId);
        if (section is not null)
        {
            return section.ToDomain();
        }

        throw new EntityNotFoundException<Section>(sectionId);
    }
}