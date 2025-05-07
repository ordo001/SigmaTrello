using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Repositories;

public interface ICardRepository
{
    public Task AddCard(Card card);
    public Task<List<Card?>> GetCardsSection(Guid sectionId);
    public Task<Card?> GetCard(Guid cardId);
    public Task RemoveCard(Card card);
    public Task UpdateCard(Card card);
}