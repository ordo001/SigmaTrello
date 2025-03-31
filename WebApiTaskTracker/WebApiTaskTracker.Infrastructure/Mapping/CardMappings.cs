using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Infrastructure.Mapping
{
    public static class CardMappings
    {
        public static Domain.Models.Card ToDomain(this Data.Card card)
        {
            return new Domain.Models.Card(card.Id, card.Name, card.Description, card.Position, card.IdUser, card.IdSection);
        }
        public static Data.Card ToEntity(this Domain.Models.Card card)
        {
            return new Data.Card
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                Position = card.Position,
                IdSection = card.IdSection
            };
        }
    }
}
