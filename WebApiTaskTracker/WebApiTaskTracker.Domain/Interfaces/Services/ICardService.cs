using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Domain.Interfaces.Services;

public interface ICardService
{
    public Task<List<Card?>> GetCardSection(Guid sectionId);
    public Task AddCard(Guid sectionId, Guid creatorId, string name, int position);
    public Task RemoveCard(Guid cardId);
    public Task<Card> UpdateCardById(Guid cardId, string? name, string? description, int? position);
}