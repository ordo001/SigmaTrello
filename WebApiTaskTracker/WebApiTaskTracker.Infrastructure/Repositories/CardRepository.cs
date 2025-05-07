using Microsoft.EntityFrameworkCore;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Infrastructure.Data;
using WebApiTaskTracker.Infrastructure.Mapping;
using Card = WebApiTaskTracker.Domain.Models.Card;

namespace WebApiTaskTracker.Infrastructure.Repositories;

public class CardRepository(TaskTrackerContext taskTrackerContext) : ICardRepository
{
    private readonly TaskTrackerContext _taskTrackerContext = taskTrackerContext; 
    public async Task AddCard(Card card)
    {
        await _taskTrackerContext.Cards.AddAsync(card.ToEntity());
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task<List<Card?>> GetCardsSection(Guid sectionId)
    {
        return (await _taskTrackerContext.Cards
            .AsNoTracking()
            .Where(c => c.IdSection == sectionId)
            .Select(c => c.ToDomain())
            .ToListAsync())!; 
    }

    public async Task<Card?> GetCard(Guid cardId)
    {
        var card = await _taskTrackerContext.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
        return card.ToDomain();
    }
    
    public async Task RemoveCard(Card card)
    {
        _taskTrackerContext.Cards.Remove(card.ToEntity());
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task UpdateCard(Card card)
    {
        _taskTrackerContext.Cards.Update(card.ToEntity());
        await _taskTrackerContext.SaveChangesAsync(); 
    }
}