using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.Models
{
    public class Section
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid IdBoard { get; set; }
        public Board Board { get; set; }

        private List<Card> _cards = new();
        public ICollection<Card> Cards => _cards;

        public Section(Guid id, Guid boardId, int position,string name, List<Card>? cards = null)
        {
            Id = id;
            IdBoard = boardId;
            Name = name;
            Position = position;
            _cards = cards ?? new();
        }

        public Section(Guid boardId, int position, string name, List<Card>? cards = null)
        {
            Id = Guid.NewGuid();
            IdBoard = boardId;
            Name = name;
            Position = position;
            _cards = cards ?? new();
        }

        public void AddCard(Card card)
        {
            if (_cards.Any(c => c.Id == card.Id))
                throw new InvalidOperationException("Карта уже существует в этой секции");

            _cards.Add(card);
        }

        public void RemoveCard(Guid cardId)
        {
            var card = _cards.FirstOrDefault(c => c.Id == cardId);
            if (card == null)
                throw new InvalidOperationException("Карта не найдена в этой секции");

            _cards.Remove(card);
        }
    }
}
