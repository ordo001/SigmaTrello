using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdSection { get; set; }

        public Card(string name, string description, int pos, Guid idUser, Guid idSection)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Position = pos;
            IdUser = idUser;
            IdSection = idSection;
        }
        public Card(Guid id,string name, string description, int pos, Guid idUser, Guid idSection)
        {
            Id = id;
            Name = name;
            Description = description;
            Position = pos;
            IdUser = idUser;
            IdSection = idSection;
        }
    }
}
