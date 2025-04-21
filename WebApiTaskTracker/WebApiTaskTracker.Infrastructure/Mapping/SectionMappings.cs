using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Infrastructure.Mapping
{
    public static class SectionMappings
    {
        public static Domain.Models.Section ToDomain(this Data.Section section)
        {
            return new Section(
                section.Id,
                section.IdBoard,
                section.Position,
                section.Name,
                section.Cards.Select(c => c.ToDomain()).ToList()
                );
        }
        
        public static Data.Section ToEntity(this Domain.Models.Section section)
        {
            return new Data.Section
            {
                Id = section.Id,
                IdBoard = section.IdBoard,
                Position = section.Position,
                Name = section.Name,
                Cards = section.Cards.Select(c => c.ToEntity()).ToList()
            };
        }
    }
}
