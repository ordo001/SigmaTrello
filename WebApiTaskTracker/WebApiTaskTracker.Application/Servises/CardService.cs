using WebApiTaskTracker.Application.Exceptions;
using WebApiTaskTracker.Domain.Interfaces.Repositories;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Application.Servises;

public class CardService(ICardRepository cardRepository) : ICardService
{
    public async Task<List<Card?>> GetCardSection(Guid sectionId)
    {
        return await cardRepository.GetCardsSection(sectionId);
    }

    public async Task AddCard(Guid sectionId, Guid creatorId, string name, int position)
    {
        try
        {
            var card = new Card(name, position, creatorId, sectionId);
            await cardRepository.AddCard(card);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task RemoveCard(Guid cardId)
    {
        var card = await cardRepository.GetCard(cardId);
        if (card is null)
            throw new EntityNotFoundException<Card>(cardId);
        
        try
        {
            await cardRepository.RemoveCard(card);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Card> UpdateCardById(Guid cardId, string? name, string? description, int? position)
    {
        var card = await cardRepository.GetCard(cardId);
        if(card is null)
            throw new EntityNotFoundException<Card>(cardId);
        try
        {
            card.Name = name ?? card.Name;
            card.Description = description ?? card.Description;
            card.Position = position ?? card.Position;

            await cardRepository.UpdateCard(card);
            return card;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}